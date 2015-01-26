using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class BadDoor : SimpleVisualGameObject
    {
        public BadDoor(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "badDoor", GameObjectType.BadDoor)
        {
            markAsTransparent();
        }
    }
}
