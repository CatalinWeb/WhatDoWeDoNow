using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow.JSON
{
    public class GameObjectYouAre
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public GameObjectYouAre()
        {
            Type = "gameObjectYouAre";
        }
    }
}
