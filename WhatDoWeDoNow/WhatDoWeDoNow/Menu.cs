using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Menu : GameObject
    {
        private string textureLocation;
        private Texture2D texture;
        List<MenuButton> menuButtons;

        public Menu(Vector2 dimensions) :
            base(new Vector2(0, 0), dimensions, GameObjectType.Other)
        {
            this.textureLocation = "Menu/backgroundMainMenu";
            menuButtons = new List<MenuButton>();


            int buttonWidth = 200;
            int buttonHeight = 50;

            int centerPosX = ((int)getDimensions().X - buttonWidth) / 2;
            int centerPosY = ((int)getDimensions().Y - buttonHeight) / 2;

            centerPosY = 150;

            menuButtons.Add(new MenuButtonInGame(new Rectangle(centerPosX, centerPosY, buttonWidth, buttonHeight)));
            menuButtons.Add(new MenuButtonExit(new Rectangle(centerPosX, centerPosY + 200, buttonWidth, buttonHeight)));
        }

        public Vector2 getDimensions()
        {
            return new Vector2(dimensions.Width, dimensions.Height);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, dimensions.Width, dimensions.Height), Color.White);
            foreach (MenuButton button in menuButtons)
            {
                spriteBatch.Draw(button.texture, button.surface, Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void UpdateControl(MouseState mouseState)
        {
            Rectangle cursorRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            foreach (MenuButton button in menuButtons)
            {
                if (button.surface.Intersects(cursorRectangle) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    button.onClick(ref TheGame.Instance.gameState);
                }
            }

        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            texture = graphicsContentLoader.Get(textureLocation);
            foreach (MenuButton button in menuButtons)
            {
                button.texture = graphicsContentLoader.Get(button.textureLocation);
            }
            isInitialized = true;
        }
    }
}
