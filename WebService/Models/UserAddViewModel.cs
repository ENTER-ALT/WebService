using System.ComponentModel.DataAnnotations;
using WebService.Domain.Entities;

namespace WebService.Models
{
    public class UserAddViewModel
    {

        public UserAddViewModel(List<UserInfo> users)
        {
            if (users == null)
            {
                infoTable = new List<UserInfo>();
            }
            else
            {
                infoTable = users;
            }
        }
        public UserAddViewModel() : this(new List<UserInfo>())
        {
        }

        [Required]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Логин пользователя")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль пользователя")]
        public string Password { get; set; }

        [Display(Name = "Все пользователи")]
        public List<UserInfo> infoTable { get; set; }
    }
}
