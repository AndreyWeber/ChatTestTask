using System;
using System.Linq;

using ChatTestTask.Data;
using ChatTestTask.Data.Entities;
using Microsoft.AspNet.SignalR;

namespace ChatTestTask.Hubs
{
    public class ChatTestTaskHub : Hub
    {
        private const string LastMessageDateNever = "<never>";
        private const string LastMessageDateTimeFormat = "MMM ddd d HH:mm yyyy";
        private const string DefaultChatName = "TestChat";
        private const string ChatMessagePostingDateFormat = "dd/MM/yyyy HH:mm";

        public void Hello(string userName)
        {
            using (var uow = new UnitOfWork())
            {
                // Get current user
                var user = uow.ChatUserRepository.GetList().FirstOrDefault(u => u.DisplayName.Equals(userName));
                // Check if user exists and create it if not
                if (user == null)
                {
                    uow.ChatUserRepository.Add(new ChatUser{ DisplayName = userName });
                    uow.Commit();
                }

                // Get user last visit date
                var message =
                    uow.ChatMessageRepository.GetList()
                       .Where(m => m.Publisher.DisplayName.Equals(userName))
                       .OrderByDescending(m => m.PublishingDate)
                       .FirstOrDefault();

                // Show greeting message
                Clients.Caller.hello(userName, message == null ? LastMessageDateNever : message.PublishingDate.ToString(LastMessageDateTimeFormat));
            }
        }

        public void Send(string userName, string message)
        {
            using (var uow = new UnitOfWork())
            {
                // Create new chat message
                var pblDate = DateTime.Now;
                uow.ChatMessageRepository.Add(new ChatMessage
                    {
                        Body = message,
                        Publisher = uow.ChatUserRepository.GetList().FirstOrDefault(u => u.DisplayName.Equals(userName)),
                        PublishingDate = pblDate,
                        Chat = uow.ChatRepository.GetList().FirstOrDefault(c => c.Name.Equals(DefaultChatName))
                    });
                uow.Commit();

                // Show chat message
                Clients.All.addNewMessageToPage(userName, message, pblDate.ToString(ChatMessagePostingDateFormat));
            }
        }

        public void ShowLast20RecordsHistory()
        {
            // Show last 20 messages from current chat to user who entered the chat
            using (var uow = new UnitOfWork())
            {
                var history = uow.ChatMessageRepository.GetList().OrderByDescending(cm => cm.PublishingDate).Take(20).ToList();
                history.Reverse();
                Clients.Caller.showMessage("***** Latest 20 messages in this chat were... *****");
                history.ForEach(cm => Clients.Caller.addNewMessageToPage(uow.ChatUserRepository.Get(cm.PublisherId).DisplayName,
                    cm.Body, cm.PublishingDate.ToString(ChatMessagePostingDateFormat)));
                Clients.Caller.showMessage("***************************************************");

            }
        }
    }
}