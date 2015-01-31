using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatTestTask.Data.Entities
{
    public class ChatMessage
    {
        [Key]
        public long Id { get; set; }

        public long ChatId { get; set; }
        public long PublisherId { get; set; }

        public virtual Chat Chat { get; set; }
        public string Body { get; set; }
        public DateTime PublishingDate { get; set; }
        public virtual ChatUser Publisher { get; set; }
    }
}
