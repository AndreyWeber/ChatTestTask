using System.Data.Entity;
using ChatTestTask.Data.Entities;

namespace ChatTestTask.Data
{
    public class ChatTestTaskDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chat>()
                        .ToTable("Chat")
                        .HasMany(c => c.Messages)
                        .WithRequired(cm => cm.Chat)
                        .HasForeignKey(cm => cm.ChatId);

            modelBuilder.Entity<ChatMessage>().ToTable("ChatMessage");
;

            modelBuilder.Entity<ChatUser>()
                        .ToTable("ChatUser")
                        .HasMany(cu => cu.Messages)
                        .WithRequired(cm => cm.Publisher)
                        .HasForeignKey(cm => cm.PublisherId);
        }
    }
}
