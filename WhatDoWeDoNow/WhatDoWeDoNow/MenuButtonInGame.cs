using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class MenuButtonInGame : MenuButton
    {
        public MenuButtonInGame(Rectangle surface)
            : base(MenuButtonType.StartGame, surface, "Menu/buttonPlay")
        {
            this.surface = surface;
            this.textureLocation = textureLocation;
        }

        public override void onClick(ref GameState gameState)
        {
            gameState = GameState.Game;
        }
    }
}
