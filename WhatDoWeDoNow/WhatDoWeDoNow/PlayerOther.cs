using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class PlayerOther : Player2
    {
        public PlayerOther(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions)
        {

        }


        public override void UpdateControl(KeyboardStateCustom keyboardState)
        {
            return; // disable this
        }
    }
}
