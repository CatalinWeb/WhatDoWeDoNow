using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class SimpleVisualGameObject : GameObject
    {
        Texture2D texture;
        string textureLocation;
        bool _visible = true;
        public SimpleVisualGameObject(Vector2 pos, Vector2 dimensions, string textureLocation, GameObjectType type)
            : base(pos, dimensions, type)
        {
            this.textureLocation = textureLocation;
        }



        public override void Draw(SpriteBatch spriteBatch, bool takeIntoConsiderationTheMapPos)
        {
            if (texture == null) return;
            if (isVisible())
            {
                if(takeIntoConsiderationTheMapPos)
                    spriteBatch.Draw(texture, new Rectangle((int)pos.X - (int)TheGame.Instance.map.Pos.X, (int)pos.Y, dimensions.Width, dimensions.Height), Color.White);
                else
                    spriteBatch.Draw(texture, new Rectangle((int)pos.X                                  , (int)pos.Y, dimensions.Width, dimensions.Height), Color.White);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (texture == null) return;
            if (isVisible())
            {
                spriteBatch.Draw(texture, new Rectangle((int)pos.X - (int)TheGame.Instance.map.Pos.X, (int)pos.Y, dimensions.Width, dimensions.Height), Color.White);
            }
        }


        public override void Update(GameTime gameTime)
        {
            
        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            texture = graphicsContentLoader.Get(textureLocation);

            isInitialized = true;
        }

        public void makeInvisible()
        {
            _visible = false;
        }

        public void makeVisible()
        {
            _visible = true;
        }

        public bool isVisible()
        {
            return _visible == true;
        }

        public bool isInvisible()
        {
            return !isVisible();
        }
    }
}
