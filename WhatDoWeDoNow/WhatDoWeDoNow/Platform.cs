using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Platform : SimpleVisualGameObject
    {
        public Platform(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "platform", GameObjectType.Platform)
        {
            
        }
    }
}
