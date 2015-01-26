using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class GameSinglePlayer : GameBase
    {
        LevelScreen levelScreen;
        List<Level> Levels;
        Level currentLevel;

        GraphicsContentLoader graphicsContentLoader;
        KeyboardState oldKeyboardState;

        bool lookForLevelStartTimeAndSaveItInAVariable = false;
        double startLevelTime;
        double endLevelTime;

        Dictionary<int, int> timesForEachLevel;


        Texture2D gameBackgroundTexture;

        public GameSinglePlayer()
        {
            //both in them.
            TheGame.Instance.gameObjects = new GameObjects();
            TheGame.Instance.players = new List<Player>();
            TheGame.Instance.gameState = GameState.Game;
            TheGame.Instance.map = new Map();


            timesForEachLevel = new Dictionary<int, int>();

            levelScreen = new LevelScreen();

            //levels
            Levels = new List<Level>();
            Levels.Add(new LevelCollideWithGuy());
            Levels.Add(new LevelCollideWithDoor());
            //Levels.Add(new LevelCollideWithGuy());
            Levels.Add(new LevelRescureTheGuyThroughTheDoor());
            //Levels.Add(new LevelCollideWithKeyFromScreen2());
            Levels.Add(new LevelCollideWithKeyFromScreen2AndColideWithDoor());
            Levels.Add(new LevelCollideWith2KeysAndCollideWithGuy());
            Levels.Add(new LevelWaitForNSecondsAndWin());
            Levels.Add(new LevelGetKilledIntentionallyByABullet());

            Levels.Add(new LevelFallThroughAPlatformCrackToWin());


            Levels.Add(new LevelChooseFromEitherOneOfTwoDoorsToWin());
            Levels.Add(new LevelChooseFromGoodAndBadDoor());
            Levels.Add(new LevelTwoPlayersCollision());



            //Levels.Add(new LevelFallThroughAPlatformCrackAndDieAndGetBackUpAndGetCookie());



            Levels.Add(new Level3SwitchesMatchCombination());
            Levels.Add(new LevelTwoPlayersHaveToKillEachOtherToContinue());
            Levels.Add(new LevelGetGunAndShootGuy()); // @TODO: test this
            Levels.Add(new LevelGetTheCookieAndCollideWithRightWall());
            Levels.Add(new LevelMovableDoorOnCollisionWhereIsItToWin());

            startNthlevel(1);
            //startNthLevelFromTheEnd(1);
        }


        private void startNthlevel(int n)
        {
            if ((n-1) < 0 || n > Levels.Count) return;
            currentLevel = Levels[n - 1];
            initLevel(currentLevel);
        }

        private void startNthLevelFromTheEnd(int n)
        {
            //if (n >= 1) return;
            currentLevel = Levels[Levels.Count - n];
            initLevel(currentLevel);
        }

        private void initLevel(Level level)
        {

            initGameObjectValues();
            level.Initialize();


            //save time
            lookForLevelStartTimeAndSaveItInAVariable = true;
        }

        private int getLevelIdForLevel(Level currentLevel)
        {
            int i = 1;
            foreach (Level level in Levels)
            {
                if (level == currentLevel)
                    return i;
                ++i;
            }

            return -1;
        }



        public void initGameObjectValues()
        {
            TheGame.Instance.map.Size = new Vector2(TheGame.Instance.Width, TheGame.Instance.Height);
            TheGame.Instance.map.Pos = Vector2.Zero;
            TheGame.Instance.gameObjects.Clear();
            TheGame.Instance.players.Clear();

            TheGame.Instance.player1 = new Player1(
                    new Vector2(300, 360),
                    new Vector2(55, 130));

            TheGame.Instance.guy = new Guy(
                    new Vector2(700, 400),
                    new Vector2(100, 100));

            TheGame.Instance.platform = new Platform(
                    new Vector2(0, 500),
                    new Vector2(4000, 100));

            TheGame.Instance.door = new Door(
                    new Vector2(100, 400),
                    new Vector2(40, 100));

            TheGame.Instance.gameObjects.AddGameObject(TheGame.Instance.player1);
            TheGame.Instance.gameObjects.AddGameObject(TheGame.Instance.guy);
            TheGame.Instance.gameObjects.AddGameObject(TheGame.Instance.platform);
            TheGame.Instance.gameObjects.AddGameObject(TheGame.Instance.door);

            TheGame.Instance.players.Add(TheGame.Instance.player1);

            TheGame.Instance.player2 = null;


            //add a platform for down screen
            Platform platform = new Platform(
                    new Vector2(0, TheGame.Instance.map.Size.Y),
                    new Vector2(4000, 1));


            TheGame.Instance.gameObjects.AddGameObject(platform);
        }


        public override void Initialize()
        {

        }



        //Song song;
        public override void LoadContent(ContentManager contentManager, GraphicsContentLoader graphicsContentLoader)
        {
            this.graphicsContentLoader = graphicsContentLoader;

            levelScreen.LoadContent(contentManager);
            levelScreen.LoadContent(graphicsContentLoader);

            gameBackgroundTexture = graphicsContentLoader.Get("gameBackground");


            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                gameObject.LoadContent(graphicsContentLoader);
            }




            //song = contentManager.Load<Song>("BGM");
            
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Play(song);*


            TheGame.Instance.contentManager = contentManager;


            TheGame.Instance.playSound("BGM", true);


















        }

        public override void Update(GameTime gameTime)
        {

            TheGame.Instance.Update(gameTime);

            if (lookForLevelStartTimeAndSaveItInAVariable)
            {
                startLevelTime = gameTime.TotalGameTime.TotalSeconds;
                lookForLevelStartTimeAndSaveItInAVariable = false;
            }



            KeyboardState originalKeyboardState = Keyboard.GetState();
            KeyboardStateCustom keyboardStateCustom = KeyboardStateCustom.getKeyboardState(originalKeyboardState);
            KeyboardStateCustom oldKeyboardStateCustom = KeyboardStateCustom.getKeyboardState(oldKeyboardState);
            // Allows the game to exit

            // TODO: Add your update logic here


//#if DEBUG
            if (originalKeyboardState.IsKeyDown(Keys.Delete) && !oldKeyboardState.IsKeyDown(Keys.Delete))
                TheGame.Instance.isDebug = !TheGame.Instance.isDebug;
            if (originalKeyboardState.IsKeyDown(Keys.PageDown) && !oldKeyboardState.IsKeyDown(Keys.PageDown))
            {
                int id = getLevelIdForLevel(currentLevel);
                if (id > 0)
                    startNthlevel(id - 1);
            }
            if (originalKeyboardState.IsKeyDown(Keys.PageUp) && !oldKeyboardState.IsKeyDown(Keys.PageUp))
            {
                int id = getLevelIdForLevel(currentLevel);
                if (id < Levels.Count)
                    startNthlevel(id + 1);
            }
//#endif
            /*
            if (originalKeyboardState.IsKeyDown(Keys.R) && !oldKeyboardState.IsKeyDown(Keys.R)) //reset
            {
                int id = getLevelIdForLevel(currentLevel);
                startNthlevel(id);
            }*/

            if (TheGame.Instance.gameState == GameState.FinishLevel)
            {
                levelScreen.Update(gameTime);
                levelScreen.UpdateControl(originalKeyboardState);

                if (levelScreen.ShouldNavigateForward())
                {
                    levelScreen.Reset();
                    TheGame.Instance.gameState = GameState.Game;

                    //load the next level
                    bool thisOneFound = false;
                    bool didItFind = false;
                    foreach (Level level in Levels)
                    {
                        //if (level.Id == currentLevel.Id)
                        if (level == currentLevel)
                        {
                            thisOneFound = true;
                        }
                        else
                        {
                            if (thisOneFound == true)
                            {
                                currentLevel = level;
                                didItFind = true;
                                break;
                            }
                        }
                    }

                    if (didItFind == false)
                    {
                        TheGame.Instance.gameState = GameState.Finished;
                        TheGame.Instance.playSound("Win");
                    }
                    else
                    {
                        initLevel(currentLevel);
                    }
                }
            }
            else if (TheGame.Instance.gameState == GameState.Game)
            {
                foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
                {
                    GameObject gameObject = keyValuePair.Value;
                    if (!gameObject.isInitialized)
                        gameObject.LoadContent(graphicsContentLoader);
                    gameObject.Update(gameTime);
                }

                //update player controls
                TheGame.Instance.player1.UpdateControl(keyboardStateCustom);
                if (TheGame.Instance.player2 != null)
                    TheGame.Instance.player2.UpdateControl(keyboardStateCustom);


                currentLevel.Update(gameTime);
                currentLevel.UpdateControl(originalKeyboardState);

                if (currentLevel.isComplete())
                {
                    endLevelTime = gameTime.TotalGameTime.TotalSeconds;
                    levelScreen.Seconds = (int)Math.Round(endLevelTime - startLevelTime);
                    levelScreen.Level = getLevelIdForLevel(currentLevel);

                    timesForEachLevel[levelScreen.Level]= levelScreen.Seconds;
                    TheGame.Instance.gameState = GameState.FinishLevel;
                    //levelScreen.Level = currentLevel.Id;
                }
                else
                {

                    foreach (Player player in TheGame.Instance.players)
                    {
                        //fix the player to the map player
                        if (player.getCollisionRectangle().X < 0)
                        {
                            player.setPosX(0);
                        }
                        if (player.getCollisionRectangle().X + player.getCollisionRectangle().Width > TheGame.Instance.map.Size.X)
                        {
                            player.setPosX(TheGame.Instance.map.Size.X - player.getCollisionRectangle().Width);
                        }

                        //VIEWPORT stuff.
                        if (player.getCollisionRectangle().X + player.getCollisionRectangle().Width > TheGame.Instance.Width * 2)
                        {
                            levelScreen.setPos(new Vector2(TheGame.Instance.Width * 2, 0));
                            TheGame.Instance.platform.setPosX(TheGame.Instance.Width * 2);
                            TheGame.Instance.map.Pos = new Vector2(TheGame.Instance.Width * 2, 0);
                        }
                        else if (player.getCollisionRectangle().X + player.getCollisionRectangle().Width > TheGame.Instance.Width)
                        {
                            levelScreen.setPos(new Vector2(TheGame.Instance.Width, 0));
                            TheGame.Instance.platform.setPosX(TheGame.Instance.Width);
                            TheGame.Instance.map.Pos = new Vector2(TheGame.Instance.Width, 0);
                        }


                        // @TODO: fix this
                        
                        if (player.getCollisionRectangle().X < TheGame.Instance.Width)
                        {
                            levelScreen.setPos(new Vector2(0, 0));
                            TheGame.Instance.platform.setPosX(0);
                            TheGame.Instance.map.Pos = new Vector2(0, 0);
                        }
                    }
                }
            }
            else if (TheGame.Instance.gameState == GameState.Finished)
            {
                if (originalKeyboardState.IsKeyDown(Keys.Enter) && !oldKeyboardState.IsKeyDown(Keys.Enter))
                    FinalGameScreenFinishedNextActionExecute();
            }

            if (keyboardStateCustom.IsKeyDown(KeysMe.PauseGame) && !oldKeyboardStateCustom.IsKeyDown(KeysMe.PauseGame) && TheGame.Instance.gameState == GameState.Game)
            {
                TheGame.Instance.gameState = GameState.Paused;
            }
            else if (keyboardStateCustom.IsKeyDown(KeysMe.PauseGame) && !oldKeyboardStateCustom.IsKeyDown(KeysMe.PauseGame) && TheGame.Instance.gameState == GameState.Paused)
            {
                TheGame.Instance.gameState = GameState.Game;
            }

            oldKeyboardState = originalKeyboardState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (TheGame.Instance.gameState == GameState.FinishLevel)
            {
                levelScreen.Draw(spriteBatch);
            }
            else if (TheGame.Instance.gameState == GameState.Game)
            {

                spriteBatch.Draw(gameBackgroundTexture, new Rectangle(0, 0, TheGame.Instance.Width, TheGame.Instance.Height), Color.White);


                foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
                {
                    GameObject gameObject = keyValuePair.Value;
                    if (gameObject == TheGame.Instance.player1) continue;
                    if (gameObject == TheGame.Instance.player2) continue;
                    gameObject.Draw(spriteBatch);
                }

                if (TheGame.Instance.getPlayer().isDead())
                    spriteBatch.DrawString(TheGame.Instance.spriteFont, "YOU ARE DEAD!", new Vector2(50, 50), Color.Blue, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);

                TheGame.Instance.player1.Draw(spriteBatch);
                if (TheGame.Instance.player2 != null)
                    TheGame.Instance.player2.Draw(spriteBatch);
            }
            else if (TheGame.Instance.gameState == GameState.Paused)
            {
                levelScreen.JustDrawIt(spriteBatch);
                spriteBatch.DrawString(TheGame.Instance.spriteFont, "Paused!", new Vector2(10, 50), Color.Blue);
            }
            else if (TheGame.Instance.gameState == GameState.Finished)
            {
                levelScreen.JustDrawIt(spriteBatch);
                spriteBatch.DrawString(TheGame.Instance.spriteFont, "FINISHED DUDE! OMGGGG!!!!11", new Vector2(50, 50), Color.Blue);

                //calculate score
                int score = 0;
                //timesForEachLevel
                foreach (KeyValuePair<int, int> keyValuePair in timesForEachLevel)
                {
                    score += keyValuePair.Value;
                }
                spriteBatch.DrawString(TheGame.Instance.spriteFont, "IT TOOK YOU " + score + " SECONDS TO FINISH THE GAME!", new Vector2(50, 150), Color.Green);
                spriteBatch.DrawString(TheGame.Instance.spriteFont, "By Dead Batteries Free of Charge: Nathan and Ioan.", new Vector2(50, 350), Color.Red);
                spriteBatch.DrawString(TheGame.Instance.spriteFont, "FOR THE GAME JAM!", new Vector2(50, 420), Color.Red);
                spriteBatch.DrawString(TheGame.Instance.spriteFont, "in Grimsby", new Vector2(50, 460), Color.Red);
            }
            
        }

        void FinalGameScreenFinishedNextActionExecute()
        {
            TheGame.Instance.isGameRunning = false;
        }
    }
}
