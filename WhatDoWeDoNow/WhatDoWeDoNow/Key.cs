using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Key : SimpleVisualGameObject
    {
        //bool pickedUp = false;
        public Key(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "key", GameObjectType.Key)
        {
            markAsTransparent();
        }

        public void PickedUp()
        {
            makeInvisible();
        }
    }
}
