using System.ComponentModel.DataAnnotations;

namespace WebService.Domain.Entities
{
    public class MessageItem : BaseEntity, IComparable<MessageItem>, IEquatable<MessageItem>
    {
        [Display(Name = "Автор сообщения(имя пользователя)")]
        public virtual string AuthorName { get; set; }

        [Display(Name = "Содержимое сообщения")]
        public virtual string MessageText { get; set; }

        public int CompareTo(MessageItem? other)
        {
            if (other == null) return 1;
            return DateAdded.CompareTo(other.DateAdded);
        }

        public bool Equals(MessageItem? other)
        {
            if (other == null) return false;
            return DateAdded.Equals(other.DateAdded);
        }
    }
}
