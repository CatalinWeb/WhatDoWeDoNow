using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Block : SimpleVisualGameObject // for debugging the jumpings only
    {
        public Block(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "block", GameObjectType.Block)
        {
        }
    }
}
