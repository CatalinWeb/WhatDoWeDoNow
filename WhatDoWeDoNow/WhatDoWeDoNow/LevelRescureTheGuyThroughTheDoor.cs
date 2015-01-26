using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelRescureTheGuyThroughTheDoor : Level
    {
        public LevelRescureTheGuyThroughTheDoor()
            : base()
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //check if the player should be followed by the guy

            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.guy.getRangeCollisionRange()))
            {
                TheGame.Instance.guy.followPlayer();
            }

            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.door.getCollisionRectangle()) &&
                TheGame.Instance.guy.getIsFollowing() == true)
            {
                markAsComplete();
            }

        }
    }
}
