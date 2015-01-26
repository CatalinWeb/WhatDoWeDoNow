using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Door : SimpleVisualGameObject
    {
        public Door(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "door", GameObjectType.Door)
        {
        }

        public override bool isColidable()
        {
            return false;
        }
    }
}
