using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ChatTestTask.Data.Entities
{
    public class Chat
    {
        public Chat()
        {
            Messages = new Collection<ChatMessage>();
        }

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; }
    }
}
