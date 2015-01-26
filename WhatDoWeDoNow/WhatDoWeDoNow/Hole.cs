using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Hole : SimpleVisualGameObject
    {
        public Hole(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "hole", GameObjectType.Other)
        {
            markAsTransparent();
        }
    }
}
