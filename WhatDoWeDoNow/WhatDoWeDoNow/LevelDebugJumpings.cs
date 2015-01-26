using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelDebugJumpings : Level
    {
        public LevelDebugJumpings() : base()
        {

        }

        public override void Initialize()
        {
            DeleteAllObjectsButPlatformAndPlayer();

            Block block;

            block = new Block(
                    new Vector2(450, 450),
                    new Vector2(600, 50));

            TheGame.Instance.gameObjects.AddGameObject(block);

            block = new Block(
                    new Vector2(550, 400),
                    new Vector2(400, 50));

            TheGame.Instance.gameObjects.AddGameObject(block);

            block = new Block(
                    new Vector2(650, 350),
                    new Vector2(200, 50));

            TheGame.Instance.gameObjects.AddGameObject(block);


        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }
    }
}
