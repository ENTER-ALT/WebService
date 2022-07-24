using System.ComponentModel.DataAnnotations;
using WebService.Domain.Entities;

namespace WebService.Models
{
    public class SendMessageViewModel
    {

        public SendMessageViewModel(List<MessageItem> messages)
        {
            if (messages == null)
            {
                Chat = new List<MessageItem>();
            }
            else
            {
                Chat = messages;
            }
            Chat.Sort();
        }
        public SendMessageViewModel():this(new List<MessageItem>())
        {
        }

        [Required]
        [Display(Name = "Логин пользователя")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Содержимое сообщения")]
        public string? Message { get; set; }

        [Display(Name = "Все пользователи")]
        public List<MessageItem> Chat{ get; set; }
    }
}
