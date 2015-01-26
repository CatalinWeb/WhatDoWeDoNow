using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelGetKilledIntentionallyByABullet : Level
    {
        Gun gun;
        double secondsWhenLevelEntered;
        int secondsToWaitBetweenFires = 1;

        public LevelGetKilledIntentionallyByABullet()
            : base()
        {
        }

        public override void Initialize()
        {
            gun = new Gun(
                new Vector2(TheGame.Instance.map.Size.X - 200, 400),
                new Vector2(100, 100));

            TheGame.Instance.gameObjects.AddGameObject(gun);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (secondsWhenLevelEntered == 0.0)
            {
                secondsWhenLevelEntered = gameTime.TotalGameTime.TotalSeconds;
                return;
            }


            if (secondsWhenLevelEntered + secondsToWaitBetweenFires < gameTime.TotalGameTime.TotalSeconds)
            {
                TheGame.Instance.Fire(new Vector2(TheGame.Instance.map.Size.X - 200, 400) + new Vector2(20, 20),
                    Direction.Left, 50.0f);


                secondsWhenLevelEntered = gameTime.TotalGameTime.TotalSeconds;
            }

            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                if (gameObject.Type == GameObjectType.Bullet)
                {
                    if (gameObject.getCollisionRectangle().Intersects(TheGame.Instance.getPlayer().getCollisionRectangle()))
                    {
                        markAsComplete();
                        break;
                    }
                }
            }
        }
    }
}
