using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class TheGame
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public ContentManager contentManager;



        SoundEffect song2;
        SoundEffectInstance soundEffectInstance2;
        public void playSound(string location, bool infinite = false)
        {
            if (infinite == false)
            {
                SoundEffect song;
                song = contentManager.Load<SoundEffect>(location);
                SoundEffectInstance soundEffectInstance = song.CreateInstance();
                soundEffectInstance.IsLooped = infinite;
                soundEffectInstance.Play();
            }
            else
            {
                SoundEffect song2;
                song2 = contentManager.Load<SoundEffect>(location);
                soundEffectInstance2 = song2.CreateInstance();
                soundEffectInstance2.IsLooped = infinite;
                soundEffectInstance2.Play();
            }
            
        }










        //public List<GameObject> gameObjects;
        public GameObjects gameObjects;

        public Player player1;
        public Player player2;
        public List<Player> players;
        public Guy guy;
        public Platform platform;
        public Door door;

        public Map map;
        public SpriteFont spriteFont;

        public PlayerMe playerMe; // for multiplayer

#if DEBUG
        public bool isDebug = true;
#else
        public bool isDebug = false;
#endif
        public GameState gameState;
        public bool isGameRunning = true;

        public double distanceBetweenPoints(Vector2 v1, Vector2 v2)
        {
            return Math.Sqrt(Math.Pow((v2.X - v1.X), 2) + Math.Pow((v2.Y - v1.Y), 2));
        }

        public WebsocketClient websocketClient;
        public TheGame()
        {


        }

        public bool isMultiPlayer()
        {
            return TheGame.Instance.websocketClient != null;
        }

        
        public string makeGameobjectPositionChangeFromGameObject(GameObject gameObject)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new JSON.GameObjectPositionChange { Id = TheGame.Instance.gameObjects.getIdFor(gameObject), X = (int)gameObject.getPos().X, Y = (int)gameObject.getPos().Y });
        }

        public Player getPlayer()
        {
            return player1;
        }



        private decimal lastFiredBullet = 0;
        static private decimal bulletFireInterval = 40000;

        public void Update(GameTime gameTime)
        {
            lastFiredBullet += gameTime.TotalGameTime.Milliseconds;
        }


        public Bullet Fire(Vector2 firePos, Direction playerDirection, float velocity = 20.0f)
        {
            if (lastFiredBullet - bulletFireInterval >= 0)
            {
                lastFiredBullet %= bulletFireInterval;
                //fire a bullet
            }
            else
            {
                return null;
            }
            TheGame.Instance.playSound("Shoot");
            float bulletSpeed = velocity * 10;

            Vector2 bulletVelocity = new Vector2(0, 0);
            if (playerDirection == Direction.Right)
                bulletVelocity.X += bulletSpeed;
            if (playerDirection == Direction.Down)
                bulletVelocity.Y += bulletSpeed;
            if (playerDirection == Direction.Left)
                bulletVelocity.X += -bulletSpeed;
            if (playerDirection == Direction.Up)
                bulletVelocity.Y += -bulletSpeed;

            Bullet bullet = new Bullet(firePos,
                bulletVelocity);

            gameObjects.AddGameObject(bullet);


            return bullet;

        }




        #region stuff

        static readonly TheGame _instance = new TheGame();

        public static TheGame Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion
    }
}
