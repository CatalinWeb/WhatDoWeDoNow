using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelTwoPlayersHaveToKillEachOtherToContinue : Level
    {
        Vector2 initialPlayer2Position;
        public LevelTwoPlayersHaveToKillEachOtherToContinue()
            : base()
        {
            initialPlayer2Position = new Vector2(800, 360);
        }

        public override void Initialize()
        {
            DeleteAllObjectsButPlatformAndPlayer();

            TheGame.Instance.player1.GiveGun();

            TheGame.Instance.player2 = new Player2(
                    initialPlayer2Position,
                    new Vector2(55, 130));

            TheGame.Instance.player2.makeFemale();

            TheGame.Instance.gameObjects.AddGameObject(TheGame.Instance.player2);
            TheGame.Instance.players.Add(TheGame.Instance.player2);

            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //keep cheking if player2 made a movement.
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                if (gameObject.Type == GameObjectType.Bullet)
                {
                    if (gameObject.getCollisionRectangle().Intersects(TheGame.Instance.player2.getCollisionRectangle()) ||
                        gameObject.getCollisionRectangle().Intersects(TheGame.Instance.guy.getCollisionRectangle()))
                    {
                        markAsComplete();
                        break;
                    }
                }
            }
        }
    }
}
