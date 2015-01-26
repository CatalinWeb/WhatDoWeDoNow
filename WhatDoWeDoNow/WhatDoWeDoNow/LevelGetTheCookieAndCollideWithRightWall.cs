using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelGetTheCookieAndCollideWithRightWall :Level
    {
        Key key;
        bool hasKey = false;

        CollisionObject collisionObject;

        protected void InitializePlatformsAndKey()
        {
            int xx = 890;
            Platform platform1, platform2, platform3;

            platform1 = new Platform(
                    new Vector2(0 + xx, 400),
                    new Vector2(300, 100));
            platform2 = new Platform(
                    new Vector2(100 + xx, 300),
                    new Vector2(200, 100));
            platform3 = new Platform(
                    new Vector2(200 + xx, 200),
                    new Vector2(100, 100));

            TheGame.Instance.gameObjects.AddGameObject(platform1);
            TheGame.Instance.gameObjects.AddGameObject(platform2);
            TheGame.Instance.gameObjects.AddGameObject(platform3);



            key = new Key(
                    new Vector2(200 + xx, 100),
                    new Vector2(100, 100));
            TheGame.Instance.gameObjects.AddGameObject(key);
        }

        public override void Initialize()
        {
            InitializePlatformsAndKey();

            collisionObject = new CollisionObject(
                    new Vector2(TheGame.Instance.map.Size.X - 1, 0),
                    new Vector2(1, TheGame.Instance.map.Size.Y));
            TheGame.Instance.gameObjects.AddGameObject(collisionObject);


        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(key.getCollisionRectangle()))
            {
                hasKey = true;
                key.PickedUp();
            }
            if (hasKey && TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(collisionObject.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }

}
