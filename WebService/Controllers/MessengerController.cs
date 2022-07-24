using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.Domain;
using WebService.Domain.Abstractions;
using WebService.Domain.Entities;
using WebService.Models;
using WebService.Structs;
using WebService.Enums;
using WebService.Service;

namespace WebService.Controllers
{
    public class MessengerController : Controller
    {
        #region PrivateFields

        private IMessageItemUpdater _messageManager;
        private IUserInfoUpdater _userManager;

        private bool MessagesManagerAvaible => _messageManager != null && _messageManager.ContextAvaible;
        private bool UsersManagerAvaible => _userManager != null && _userManager.ContextAvaible;
        private bool ManagersAvaible => MessagesManagerAvaible && UsersManagerAvaible;

        #endregion

        public MessengerController(DataManager data) : base()
        {
            _messageManager = data.Messages;
            _userManager = data.Users;
        }

        public async Task<ActionResult> Send()
        {
            return View(new SendMessageViewModel(await GetMessages()));
        }

        [HttpPost]
        public async Task<ActionResult> Send(SendMessageViewModel sendMessage)
        {

            if (ModelState.IsValid)
            {
                if (await TrySendMessage(sendMessage))
                {
                    return RedirectToAction(nameof(Send));
                }
            }
            return View(sendMessage);
        }
        private async Task<bool> TrySendMessage(SendMessageViewModel message)
        {
            MessageItem tempMessage = new MessageItem()
            { AuthorName = message.Login, MessageText = message.Message };

            if (!ManagersAvaible)
            {
                ModelState.AddModelError("",ErrorMessages.DatabaseNotAvaible);
                return false;
            }
            if (await _userManager.GetUserByLogin(tempMessage.AuthorName) == null)
            {
                ModelState.AddModelError("", ErrorMessages.UserDoesNotExists);
                return false;
            }

            await _messageManager.SaveMessage(tempMessage);
            return true;
        }
        private async Task<List<MessageItem>> GetMessages()
        {
            if (!ManagersAvaible)
            {
                return null;
            }
            return await _messageManager.GetMessages();
        }
    }
}