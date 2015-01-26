using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class CollisionObject : SimpleVisualGameObject
    {
        public CollisionObject(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "collision", GameObjectType.Other)
        {
            markAsTransparent();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (TheGame.Instance.isDebug)
                base.Draw(spriteBatch);
        }
    }
}
