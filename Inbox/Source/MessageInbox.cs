namespace Inbox.Source
{
    public class MessageInbox
    {
        private readonly MessageSender _messageSender;

        public MessageInbox(MessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void ReceiveMessage(string from, string message)
        {
            _messageSender.SendMessage("", "");
        }
    }
}
