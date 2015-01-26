using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelCollideWithKeyFromScreen2 : Level
    {
        Key key;
        public LevelCollideWithKeyFromScreen2()
            : base()
        {
        }

        public override void Initialize()
        {
            TheGame.Instance.map.Size = new Microsoft.Xna.Framework.Vector2(TheGame.Instance.map.Size.X * 2, TheGame.Instance.map.Size.Y);

            key = new Key(
                    new Vector2(TheGame.Instance.Width + 500, 400),
                    new Vector2(100, 100));

            TheGame.Instance.gameObjects.AddGameObject(key);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(key.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
