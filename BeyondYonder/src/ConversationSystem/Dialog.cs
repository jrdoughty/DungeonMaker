using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondYonder.src.ConversationSystem
{
    class Dialog
    {
        private string _dialog;
        private string _character = "NONE";
        private string _mood = "DEFAULT";

        Dialog(string dialog, string character, string mood)
        {
            _character = character;
            _dialog = dialog;
            _mood = mood;
        }

        Dialog(string dialog, string character)
        {
            _character = character;
            _dialog = dialog;
        }

        Dialog(string dialog)
        {
            _dialog = dialog;
        }

        public string Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public string DialogText
        {
            get { return _dialog; }
            set { _dialog = value; }
        }

        public string Mood
        {
            get { return _mood; }
            set { _mood = value; }
        }
    }
}
