using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow.JSON
{
    public class GameObject
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public int dimensionX { get; set; }
        public int dimensionY { get; set; }
        public int Id { get; set; }
        public string GameObjectType { get; set; }
        public string Type { get; set; }


        public GameObject()
        {
            Type = "gameObject";
        }
    }
}
