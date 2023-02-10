using Inbox.Source;

namespace Inbox.Test
{
    [TestClass]
    public class MessageInboxTest
    {
        private MessageSender _sender;
        private MessageInbox _inbox;

        [TestInitialize]
        public void Initialize()
        {
            _sender = new MessageSender();
            _inbox = new MessageInbox(_sender);
        }

        [TestMethod]
        public void WhenMessageArrivesThenSendMessageToReception()
        {
            // When
            _inbox.ReceiveMessage("Elon Musk", "Hello Cegeka!");

            // Then
            CollectionAssert.AreEquivalent(_sender.Messages, new[] { ("reception", "Hello Cegeka!") });
        }

        [TestMethod]
        public void WhenMessageArrivesContainingCVThenSendMessageToReception()
        {
            // When
            _inbox.ReceiveMessage("Elon Musk", "CV for Cegeka!");

            // Then
            CollectionAssert.AreEquivalent(_sender.Messages, new[] { ("recruitment", "CV for Cegeka!") });
        }

        [TestMethod]
        public void WhenAMessageArrivesContainingTheWordCVButNowWithLowerCaseThenSendMessageToRecruitment()
        {
            // When
            _inbox.ReceiveMessage("Elon Musk", "cv for Cegeka!");

            // Then
            CollectionAssert.AreEquivalent(_sender.Messages, new[] { ("recruitment", "cv for Cegeka!") });
        }

        [TestMethod]
        public void WhenMessageArrivesButOnlyFromContainsCVThenStillSendMessageToReception()
        {
            // When
            _inbox.ReceiveMessage("CV Spammer", "Big news for Cegeka!");

            // Then
            CollectionAssert.AreEquivalent(_sender.Messages, new[] { ("reception", "Big news for Cegeka!") });
        }
    }
}