using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public abstract class Level
    {

        private bool _finished;



        public Level()
        {
        }

        //public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);



        public void DeleteAllObjectsButPlatformAndPlayer()
        {
            for (int w = TheGame.Instance.gameObjects.Count - 1; w >= 0; w--)
            {
                KeyValuePair<int, GameObject> keyValuePair = TheGame.Instance.gameObjects.ElementAt(w);
                GameObject gameObject = keyValuePair.Value;

                if (gameObject != TheGame.Instance.platform && gameObject != TheGame.Instance.getPlayer())
                    TheGame.Instance.gameObjects.RemoveGameObject(gameObject);
            }
        }

        public virtual void Initialize() { }
        public virtual void UpdateControl(KeyboardState keyboardState) { }

        protected void markAsComplete()
        {
            _finished = true;
        }

        public bool isComplete()
        {
            return _finished;
        }
    }
}
