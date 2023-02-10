namespace Inbox.Source
{
    public class MessageSender
    {
        public List<(string, string)> Messages { get; } = new List<(string, string)>();

        public void SendMessage(string to, string message)
        {
            // To keep things easy for this exercise we just keep the messages here in memory
            Messages.Add((to, message));
        }
    }
}
