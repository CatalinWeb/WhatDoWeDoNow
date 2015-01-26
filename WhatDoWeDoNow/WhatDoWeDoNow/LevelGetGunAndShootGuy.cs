using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelGetGunAndShootGuy : Level
    {
        Gun gun;
        bool hasGun = false;

        public LevelGetGunAndShootGuy()
            : base()
        {
        }

        public override void Initialize()
        {
            TheGame.Instance.gameObjects.RemoveGameObject(TheGame.Instance.door);

            TheGame.Instance.platform.setWidth(0);


            Platform platform1, platform2;
            platform1 = new Platform(
                    new Vector2(0, 500),
                    new Vector2(50, 100));
            platform2 = new Platform(
                    new Vector2(151, 500),
                    new Vector2(4000, 100));

            TheGame.Instance.gameObjects.AddGameObject(platform1);
            TheGame.Instance.gameObjects.AddGameObject(platform2);




            //so it doesn't go through the screen
            Platform platform3;
            platform3 = new Platform(
                    new Vector2(50, 600),
                    new Vector2(100, 1));
            TheGame.Instance.gameObjects.AddGameObject(platform3);


            gun = new Gun(
                new Vector2(50, 500),
                new Vector2(100, 100));

            gun.markAsTransparent();

            TheGame.Instance.gameObjects.AddGameObject(gun);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if(TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(gun.getCollisionRectangle())) {
                hasGun = true;
                gun.PickedUp();
                TheGame.Instance.getPlayer().GiveGun();
            }

            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                if (gameObject.Type == GameObjectType.Bullet)
                {
                    if (gameObject.getCollisionRectangle().Intersects(TheGame.Instance.guy.getCollisionRectangle()))
                    {
                        markAsComplete();
                        break;
                    }
                }
            }
        }
    }
}
