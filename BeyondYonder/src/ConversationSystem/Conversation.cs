using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.ConversationSystem
{
    class Conversation
    {
        Dialog[] _dialogs;

        Conversation(Dialog[] dialogs)
        {
            _dialogs = dialogs;
        }

        public Dialog[] Dialog
        {
            get { return _dialogs; }
            set { _dialogs = value; }
        }
    }
}
