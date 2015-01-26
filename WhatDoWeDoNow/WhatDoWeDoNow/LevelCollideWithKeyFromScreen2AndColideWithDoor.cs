using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelCollideWithKeyFromScreen2AndColideWithDoor : Level
    {
        Key key;
        bool keyColided = false;
        public LevelCollideWithKeyFromScreen2AndColideWithDoor()
            : base()
        {
        }

        public override void Initialize()
        {
            TheGame.Instance.map.Size = new Microsoft.Xna.Framework.Vector2(TheGame.Instance.map.Size.X * 2, TheGame.Instance.map.Size.Y);

            key = new Key(
                    new Vector2(1500, 400),
                    new Vector2(100, 100));

            TheGame.Instance.gameObjects.AddGameObject(key);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(key.getCollisionRectangle()))
            {
                keyColided = true;
                key.PickedUp();
            }

            if (keyColided == true && TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.guy.getHeadCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
