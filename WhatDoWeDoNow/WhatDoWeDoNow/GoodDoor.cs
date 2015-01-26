using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class GoodDoor : SimpleVisualGameObject
    {
        public GoodDoor(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "goodDoor", GameObjectType.GoodDoor)
        {
            markAsTransparent();
        }
    }
}
