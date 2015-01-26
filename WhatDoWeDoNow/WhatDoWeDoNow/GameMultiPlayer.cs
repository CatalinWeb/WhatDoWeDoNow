using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class GameMultiPlayer : GameBase
    {
        GraphicsContentLoader graphicsContentLoader;
        KeyboardState oldKeyboardState;
        public GameMultiPlayer()
        {
            //both in them.
            TheGame.Instance.gameObjects = new GameObjects();
            TheGame.Instance.players = new List<Player>();
            TheGame.Instance.gameState = GameState.Game;
            TheGame.Instance.map = new Map();


            TheGame.Instance.websocketClient = new WebsocketClient();
            TheGame.Instance.websocketClient.Init();


            initGameObjectValues();
        }

        public override void Initialize()
        {
        }


        public void initGameObjectValues()
        {
            TheGame.Instance.map.Size = new Vector2(TheGame.Instance.Width, TheGame.Instance.Height);
            TheGame.Instance.map.Pos = Vector2.Zero;

            /*
            TheGame.Instance.player1 = new Player1(new Vector2(300, 400), new Vector2(100, 100));

            TheGame.Instance.platform = new Platform(
                    new Vector2(0, 500),
                    new Vector2(4000, 100));

            TheGame.Instance.gameObjects.Add(TheGame.Instance.platform);

            TheGame.Instance.players.Add(TheGame.Instance.player1);
            */
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager contentManager, GraphicsContentLoader graphicsContentLoader)
        {
            this.graphicsContentLoader = graphicsContentLoader;
            //TheGame.Instance.player1.LoadContent(graphicsContentLoader);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            KeyboardState originalKeyboardState = Keyboard.GetState();
            KeyboardStateCustom keyboardStateCustom = KeyboardStateCustom.getKeyboardState(originalKeyboardState);
            KeyboardStateCustom oldKeyboardStateCustom = KeyboardStateCustom.getKeyboardState(oldKeyboardState);


            foreach(KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                //if (gameObject == TheGame.Instance.player1) continue;

                if(!gameObject.isInitialized)
                    gameObject.LoadContent(graphicsContentLoader);
                gameObject.Update(gameTime);
            }

            if (TheGame.Instance.playerMe != null)
                TheGame.Instance.playerMe.UpdateControl(keyboardStateCustom);


            oldKeyboardState = originalKeyboardState;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //draw anything but player
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                if (gameObject.Type == GameObjectType.Player) continue;
                gameObject.Draw(spriteBatch);
            }

            //draw plyers
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                if (gameObject.Type != GameObjectType.Player) continue;
                gameObject.Draw(spriteBatch);
            }
        }
    }
}
