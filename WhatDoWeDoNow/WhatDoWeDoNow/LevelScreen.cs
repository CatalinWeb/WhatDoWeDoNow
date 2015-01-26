using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelScreen : SimpleVisualGameObject
    {
        bool _shouldNavigatForward;

        public int Level { get; set; }
        public int Seconds { get; set; }
        SpriteFont spriteFont;
        public LevelScreen()
            : base(new Vector2(0, 0), new Vector2(2000, 2000), "levelScreen", GameObjectType.Other)
        {
            Reset();

            setWidth(TheGame.Instance.Width);
            setHeight(TheGame.Instance.Height);
        }

        public override void setPos(Vector2 v2)
        {
            base.setPos(new Vector2(0,0));
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            JustDrawIt(spriteBatch);
            spriteBatch.DrawString(spriteFont, "Level finished: " + Level.ToString(), new Vector2(50, 75), Color.Black, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(spriteFont, "IT TOOK YOU " + Seconds + " SECOND" + (Seconds > 0 ? "S" : "")+ " TO FINISH THIS LEVEL!", new Vector2(50, 125), Color.Blue);
        }

        public void JustDrawIt(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, false);
        }

        public void LoadContent(ContentManager contentManager)
        {
            spriteFont = contentManager.Load<SpriteFont>("SpriteFont");
        }

        public void Reset()
        {
            Level = 0;
            _shouldNavigatForward = false;
        }


        public void UpdateControl(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                triggerNavigateForward();
            }
        }



        public bool ShouldNavigateForward()
        {
            return _shouldNavigatForward;
        }


        public void triggerNavigateForward()
        {
            _shouldNavigatForward = true;
        }


    }
}
