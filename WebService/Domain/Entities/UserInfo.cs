using System.ComponentModel.DataAnnotations;

namespace WebService.Domain.Entities
{
    public class UserInfo : BaseEntity
    {
        [Display(Name = "Имя пользователя")]
        public virtual string Name { get; set; }

        [Display(Name = "Логин пользователя")]
        public virtual string Login { get; set; }

        [Display(Name = "Пароль пользователя")]
        public virtual string Password { get; set; }

    }
}
