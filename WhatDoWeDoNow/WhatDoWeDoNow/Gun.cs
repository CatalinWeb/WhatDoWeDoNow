using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Gun : SimpleVisualGameObject
    {
        public Gun(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "gun", GameObjectType.Gun)
        {
        }

        public void PickedUp()
        {
            makeInvisible();
        }
    }
}
