using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Switch : GameObject
    {
        Texture2D textureOn;
        Texture2D textureOff;

        bool isOff = true;
        public bool playerIsHover = false;
        public Switch(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, GameObjectType.Switch)
        {
            markAsTransparent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (textureOn == null || textureOff == null) return;
            
            if(isON())
                spriteBatch.Draw(textureOn, new Rectangle((int)pos.X - (int)TheGame.Instance.map.Pos.X, (int)pos.Y, dimensions.Width, dimensions.Height), Color.White);
            else
                spriteBatch.Draw(textureOff, new Rectangle((int)pos.X - (int)TheGame.Instance.map.Pos.X, (int)pos.Y, dimensions.Width, dimensions.Height), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(getCollisionRectangle()))
                playerIsHover = true;
            else
                playerIsHover = false;
        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            textureOn = graphicsContentLoader.Get("switchOn");
            textureOff = graphicsContentLoader.Get("switchOff");

            isInitialized = true;
        }





        public void SWITCH()
        {
            isOff = !isOff;
        }

        public void ON()
        {
            isOff = false;
        }

        public void OFF()
        {
            isOff = true;
        }

        public bool isON()
        {
            return isOff == false;
        }

        public bool isOFF()
        {
            return !isON();
        }
    }
}
