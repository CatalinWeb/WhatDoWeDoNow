using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class MenuButtonExit : MenuButton
    {
        public MenuButtonExit(Rectangle surface)
            : base(MenuButtonType.StartGame, surface, "Menu/buttonExit")
        {
            this.surface = surface;
            this.textureLocation = textureLocation;
        }

        public override void onClick(ref GameState gameState)
        {
            TheGame.Instance.isGameRunning = false;
        }
    }
}
