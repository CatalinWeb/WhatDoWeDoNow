using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelTwoPlayersCollision : Level
    {
        Vector2 initialPlayer2Position;
        bool player2Moved = false;
        public LevelTwoPlayersCollision()
            : base()
        {
            initialPlayer2Position = new Vector2(300, 360);
        }

        public override void Initialize()
        {
            DeleteAllObjectsButPlatformAndPlayer();

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

            if (TheGame.Instance.player2.getPos() != initialPlayer2Position)
            {
                player2Moved = true;
            }

            if (player2Moved == true && TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.player2.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
