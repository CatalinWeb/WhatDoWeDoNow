using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public abstract class MenuButton
    {
        public MenuButtonType menuButtonType;
        public Rectangle surface;
        public string textureLocation;
        public Texture2D texture;

        public MenuButton(MenuButtonType type, Rectangle surface, string textureLocation)
        {
            this.menuButtonType = type;
            this.surface = surface;
            this.textureLocation = textureLocation;
        }

        public abstract void onClick(ref GameState gameState);
    }
}
