using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.ConversationSystem
{
    class ConversationManager
    {
        List<List<Dialog>> _conversationQueue = new List<List<Dialog>>();

        public void AddConversation(List<Dialog> dialogs)
        {
            _conversationQueue.Add(dialogs);
        }

        public List<List<Dialog>> ConversationQueue
        {
            get { return _conversationQueue; }
            //set { _conversationQueue = value; }
        }
    }
}
