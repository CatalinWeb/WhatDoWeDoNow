using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow.JSON
{
    public class GameObjectPositionChange
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }

        public GameObjectPositionChange()
        {
            Type = "gameObjectPositionChange";
        }
    }
}
