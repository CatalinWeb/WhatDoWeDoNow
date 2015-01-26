using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Guy : SimpleVisualGameObject
    {
        Texture2D collisionTexture;
        Texture2D rangeTexture;

        public int Range { get; set; }

        private bool _followPlayer;


        public Guy(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions, "guy", GameObjectType.Gun)
        {
            Range = 50;
            _followPlayer = false;
            markAsTransparent();
        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            collisionTexture = graphicsContentLoader.Get("collision");
            rangeTexture = graphicsContentLoader.Get("range");

            base.LoadContent(graphicsContentLoader);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (rangeTexture == null) return;
            if (collisionTexture == null) return;

            Rectangle rangeCollisionRangeRectangle = getRangeCollisionRange();
            rangeCollisionRangeRectangle.X -= (int)TheGame.Instance.map.Pos.X;
            if (TheGame.Instance.isDebug)
                spriteBatch.Draw(rangeTexture, rangeCollisionRangeRectangle, Color.White);

            base.Draw(spriteBatch);

            Rectangle headCollisionRectangle = getHeadCollisionRectangle();
            headCollisionRectangle.X -= (int)TheGame.Instance.map.Pos.X;
            if (TheGame.Instance.isDebug)
                spriteBatch.Draw(collisionTexture, headCollisionRectangle, Color.White);


        }

        public override bool isColidable()
        {
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            if (_followPlayer)
            {
                //left
                /*
                if (TheGame.Instance.player.getPos().X < pos.X - Range)
                {
                    pos.X = TheGame.Instance.player.getPos().X + TheGame.Instance.player.getCollisionRectangle().Width + Range;
                }*/

                //check for distance

                //if (pos.X - TheGame.Instance.player.getCollisionRectangle().X > Range)
                if (TheGame.Instance.getPlayer().getCollisionRectangle().X + TheGame.Instance.getPlayer().getCollisionRectangle().Width + Range < pos.X)
                {
                    pos.X = TheGame.Instance.getPlayer().getCollisionRectangle().X + TheGame.Instance.getPlayer().getCollisionRectangle().Width + Range;
                }

                if (pos.X + getCollisionRectangle().Width + Range < TheGame.Instance.getPlayer().getCollisionRectangle().X)
                {
                    pos.X = TheGame.Instance.getPlayer().getCollisionRectangle().X - getCollisionRectangle().Width - Range;
                }


            }




            base.Update(gameTime);
        }



        public Rectangle getHeadCollisionRectangle()
        {
            return new Rectangle((int)pos.X + 35, (int)pos.Y - 1, dimensions.Width - 70, 3);
        }
        public Rectangle getRangeCollisionRange()
        {
            return new Rectangle((int)pos.X - Range, (int)pos.Y, getCollisionRectangle().Width + Range * 2, getCollisionRectangle().Height);
        }


        public void followPlayer()
        {
            _followPlayer = true;
        }

        public bool getIsFollowing()
        {
            return _followPlayer;
        }
    }
}
