﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeyondYonder.src.Base_Classes;

namespace BeyondYonder.src.GameComponents
{
    
    class PC : Actor
    {
        protected string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
    }
}
