using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WhatDoWeDoNow
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsContentLoader graphicsContentLoader;
        int width;
        int height;
        Menu menu;
        Cursor cursor;
        GameBase game;

        public Game1()
        {
            width = 1280;
            height = 720;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

            Content.RootDirectory = "Content";

            menu = new Menu(new Vector2(width, height));

            TheGame.Instance.Width = width;
            TheGame.Instance.Height = height;



            game = new GameSinglePlayer();
            //game = new GameMultiPlayer();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            TheGame.Instance.gameState = GameState.MainMenu;
            if (TheGame.Instance.isDebug == true)
                TheGame.Instance.gameState = GameState.Game;

            cursor = new Cursor();

            game.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphicsContentLoader = new GraphicsContentLoader(Content);

            TheGame.Instance.spriteFont = Content.Load<SpriteFont>("SpriteFont");
            cursor.LoadContent(graphicsContentLoader);


            //load all the images we will need later. - cache them in the memory
            graphicsContentLoader.Load("bullet");
            graphicsContentLoader.Load("collision");
            graphicsContentLoader.Load("door");
            graphicsContentLoader.Load("gun");
            graphicsContentLoader.Load("guy");
            graphicsContentLoader.Load("key");
            graphicsContentLoader.Load("levelScreen");
            graphicsContentLoader.Load("platform");
            graphicsContentLoader.Load("player");
            graphicsContentLoader.Load("range");
            graphicsContentLoader.Load("choiceDoor");
            graphicsContentLoader.Load("goodDoor");
            graphicsContentLoader.Load("badDoor");
            graphicsContentLoader.Load("switchOff");
            graphicsContentLoader.Load("switchOn");
            graphicsContentLoader.Load("bullet");
            graphicsContentLoader.Load("hole");

            if (menu.isInitialized == false)
                menu.LoadContent(graphicsContentLoader);

            game.LoadContent(Content, graphicsContentLoader);
        }




        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (TheGame.Instance.isGameRunning == false) Exit();

            cursor.pos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            cursor.Update(gameTime);

            if (TheGame.Instance.gameState == GameState.MainMenu)
            {
                menu.Update(gameTime);
                menu.UpdateControl(Mouse.GetState());
            }
            else
            {
                game.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.FloralWhite);


            spriteBatch.Begin();
                if (TheGame.Instance.gameState == GameState.MainMenu)
                {
                    menu.Draw(spriteBatch);
                }
                else
                {
                    game.Draw(spriteBatch);
                }

                cursor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
