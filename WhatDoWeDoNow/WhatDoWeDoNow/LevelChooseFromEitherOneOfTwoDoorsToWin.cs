using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelChooseFromEitherOneOfTwoDoorsToWin : Level
    {
        ChoiceDoor choiceDoor1;
        ChoiceDoor choiceDoor2;
        public LevelChooseFromEitherOneOfTwoDoorsToWin()
            : base()
        {
        }

        public override void Initialize()
        {
            DeleteAllObjectsButPlatformAndPlayer();

            choiceDoor1 = new ChoiceDoor(
                    new Vector2(0, 400),
                    new Vector2(100, 100));

            choiceDoor2 = new ChoiceDoor(
                    new Vector2(600, 400),
                    new Vector2(100, 100));


            TheGame.Instance.gameObjects.AddGameObject(choiceDoor1);
            TheGame.Instance.gameObjects.AddGameObject(choiceDoor2);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(choiceDoor1.getCollisionRectangle()) ||
                TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(choiceDoor2.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
