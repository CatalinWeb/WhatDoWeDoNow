using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class ChoiceDoor : SimpleVisualGameObject
    {
        public ChoiceDoor(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "choiceDoor", GameObjectType.ChoiceDoor)
        {
            markAsTransparent();
        }
    }
}
