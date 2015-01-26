using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelWaitForNSecondsAndWin : Level
    {
        private int secondsToWait = 5;

        double secondsWhenLevelEntered = 0.0;



        public LevelWaitForNSecondsAndWin()
            : base()
        {

        }

        public override void Initialize()
        {
            DeleteAllObjectsButPlatformAndPlayer();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (isComplete()) return;

            if (secondsWhenLevelEntered == 0.0) {
                secondsWhenLevelEntered = gameTime.TotalGameTime.TotalSeconds;
                return;
            }

            //check if the player should be followed by the guy
            if (secondsWhenLevelEntered + secondsToWait < gameTime.TotalGameTime.TotalSeconds)
            {
                markAsComplete();
            }
        }
    }
}
