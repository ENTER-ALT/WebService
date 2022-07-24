
using Microsoft.AspNetCore.Mvc;
using WebService.Domain.Abstractions;
using WebService.Domain.Entities;
using WebService.Models;
using WebService.Service;
using WebService.Structs;
using WebService.Enums;

namespace WebService.Controllers
{
    public class UserManagementController : Controller
    {
        #region PrivateFields

        private IUserInfoUpdater _userManager;

        private bool ManagerAvaible => _userManager != null && _userManager.ContextAvaible;

        #endregion

        public UserManagementController(IUserInfoUpdater userManager) : base()
        {
            _userManager = userManager;
        }

        public async Task<ActionResult> AddUser()
        {
            return View(new UserAddViewModel(await GetUsers()));
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(UserAddViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (await TrySaveUser(user))
                {
                    return RedirectToAction(nameof(AddUser));
                }
            }
            return View(user);
        }

        private async Task<bool> TrySaveUser(UserAddViewModel user)
        {
            UserInfo tempUser = new UserInfo()
            { Name = user.Name, Login = user.Login, Password = user.Password };

            if (!ManagerAvaible)
            {
                ModelState.AddModelError("", ErrorMessages.DatabaseNotAvaible);
                return false;
            }

            if (!await _userManager.isUnique(tempUser))
            {
                ModelState.AddModelError("", ErrorMessages.UserAlreadyExists);
                return false;
            }

            await _userManager.SaveUser(tempUser);
            return true;
        }

        private async Task<List<UserInfo>> GetUsers()
        {
            if (!ManagerAvaible)
            {
                return null;
            }
            return await _userManager.GetUsers();
        }
    }
}
