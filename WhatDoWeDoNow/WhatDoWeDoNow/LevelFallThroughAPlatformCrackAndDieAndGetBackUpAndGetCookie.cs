using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelFallThroughAPlatformCrackAndDieAndGetBackUpAndGetCookie : LevelFallThroughAPlatformCrackToWin
    {
        bool didFallThroughTheCrackAndActivatedTheCollisionThing = false;
        Key key;

        public LevelFallThroughAPlatformCrackAndDieAndGetBackUpAndGetCookie()
            : base()
        {

        }


        public override void Initialize()
        {

            base.Initialize();
        }

        void addKey()
        {
            key = new Key(
                new Vector2(920, 400),
                new Vector2(100, 100));

            TheGame.Instance.gameObjects.AddGameObject(key);
        }


        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(collisionObject.getCollisionRectangle()) && didFallThroughTheCrackAndActivatedTheCollisionThing == false)
            {
                TheGame.Instance.getPlayer().Die();
                TheGame.Instance.getPlayer().setJumpHigh(TheGame.Instance.getPlayer().getJumpHigh() * 2);
                didFallThroughTheCrackAndActivatedTheCollisionThing = true;
                addKey();

                platform2.setPosX(platform1.getCollisionRectangle().X + platform1.getCollisionRectangle().Width);
                platform2.setWidth(TheGame.Instance.map.Size.X - platform1.getCollisionRectangle().Width - 125);

                hole.setPosX(TheGame.Instance.map.Size.X - platform1.getCollisionRectangle().Width);
                hole.setWidth(125);
            }

            if (didFallThroughTheCrackAndActivatedTheCollisionThing == true)
            {
                if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(key.getCollisionRectangle()))
                {
                    markAsComplete();
                }
            }
        }
    }
}
