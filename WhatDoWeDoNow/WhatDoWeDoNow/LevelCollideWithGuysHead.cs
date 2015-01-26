using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelCollideWithGuysHead : Level
    {
        public LevelCollideWithGuysHead()
            : base()
        {
        }

        public override void Initialize()
        {
            TheGame.Instance.guy.setCollidable(true);

            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //check if the player should be followed by the guy

            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.guy.getHeadCollisionRectangle()))
            {
                markAsComplete();
            }

        }
    }
}
