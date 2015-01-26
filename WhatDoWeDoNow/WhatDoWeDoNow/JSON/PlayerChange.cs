using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow.JSON
{
    public class PlayerChange
    {
        public string Type { get; set; }
        public string Change { get; set; }

        public PlayerChange(string change)
        {
            Change = change;
            Type = "playerChange";
        }
    }
}
