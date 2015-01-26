using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelFallThroughAPlatformCrackToWin : Level
    {
        protected Platform platform1;
        protected Platform platform2;
        protected CollisionObject collisionObject;
        protected Hole hole;
        public LevelFallThroughAPlatformCrackToWin()
            : base()
        {

        }

        public override void Initialize()
        {

            /*
            hole = new Hole(
                    new Vector2(20, 400),
                    new Vector2(130, 100));
            TheGame.Instance.gameObjects.AddGameObject(hole);
            */
            /*
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;

                if (gameObject.Type == GameObjectType.Platform) continue;
                if (gameObject.Type == GameObjectType.Guy) continue;

                gameObject.setPosY(gameObject.getPos().Y - 100);
            }*/

            platform1 = new Platform(
                    new Vector2(0, 500),
                    new Vector2(20, 100));
            platform2 = new Platform(
                    new Vector2(150, 500),
                    new Vector2(4000, 100));


            TheGame.Instance.gameObjects.AddGameObject(platform1);
            TheGame.Instance.gameObjects.AddGameObject(platform2);





            TheGame.Instance.gameObjects.RemoveGameObject(TheGame.Instance.door);

            TheGame.Instance.platform.setWidth(0);

            


            collisionObject = new CollisionObject(
                    new Vector2(40, 695),
                    new Vector2(100, 5));


            TheGame.Instance.gameObjects.AddGameObject(collisionObject);

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(collisionObject.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
