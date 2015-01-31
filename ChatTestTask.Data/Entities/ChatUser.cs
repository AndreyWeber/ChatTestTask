using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ChatTestTask.Data.Entities
{
    public class ChatUser
    {
        public ChatUser()
        {
            Messages = new Collection<ChatMessage>();
        }

        [Key]
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; }
    }
}
