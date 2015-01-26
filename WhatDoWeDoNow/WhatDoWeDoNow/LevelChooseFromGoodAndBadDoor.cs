using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelChooseFromGoodAndBadDoor : Level
    {
        GoodDoor goodDoor;
        BadDoor badDoor;
        public LevelChooseFromGoodAndBadDoor()
            : base()
        {
        }

        public override void Initialize()
        {
            DeleteAllObjectsButPlatformAndPlayer();

            goodDoor = new GoodDoor(
                    new Vector2(0, 380),
                    new Vector2(100, 120));

            badDoor = new BadDoor(
                    new Vector2(TheGame.Instance.map.Size.X - 100, 380),
                    new Vector2(100, 120));


            TheGame.Instance.gameObjects.AddGameObject(goodDoor);
            TheGame.Instance.gameObjects.AddGameObject(badDoor);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(badDoor.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
