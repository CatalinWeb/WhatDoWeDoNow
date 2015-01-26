using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Bullet : GameObject
    {
        public int id;

        Vector2 velocity;
        Texture2D texture;
        public Bullet(Vector2 pos, Vector2 velocity)
            : base(pos, new Vector2(20, 20), GameObjectType.Bullet)
        {
            this.velocity = velocity;

            pos.X -= getWorldRectangle().Width / 2;
            pos.Y -= getWorldRectangle().Height / 2;

            markAsTransparent();

            Type = GameObjectType.Bullet;

        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            texture = graphicsContentLoader.Get("bullet");
            isActive = true;
            isInitialized = true;
        }

        public override void Update(GameTime gameTime)
        {
            pos += velocity * (float)(gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(SpriteBatch worldDrawer)
        {
            float rotationGrades = MathHelper.Pi * 2 / 4;

            Rectangle outputRectangle = getTextureRectangle();

            //XNA doesn't rotate the sprite around the center of gravity.
            if (getDirection() == Direction.Right)
            {
                outputRectangle.X += outputRectangle.Height;
            }
            else if (getDirection() == Direction.Down)
            {
                outputRectangle.X += outputRectangle.Width;
                outputRectangle.Y += outputRectangle.Height;
            }
            else if (getDirection() == Direction.Left)
            {
                outputRectangle.Y += outputRectangle.Width;
            }
            else // if up don't to anything because that's the orientation in the sprite
            {

            }
            if(texture != null)
            worldDrawer.Draw(texture, outputRectangle, texture.Bounds, Color.White,
                            ((int)getDirection() * rotationGrades), Vector2.Zero, SpriteEffects.None, 1.0f);

        }

        public Direction getDirection()
        {
            if (velocity.Y < 0 && velocity.X == 0)
                return Direction.Up;
            else if (velocity.Y > 0 && velocity.X == 0)
                return Direction.Down;
            else if (velocity.Y == 0 && velocity.X > 0)
                return Direction.Right;
            else
                return Direction.Left;
        }

        private Rectangle getTextureRectangle()
        {
            return new Rectangle((int)(float)pos.X, (int)(float)pos.Y, 10, 15);
        }

        //get a rectangle with the sizes of the bullet in the world
        public new Rectangle getWorldRectangle()
        {
            //down, left.. not working right!
            if (getDirection() == Direction.Up || getDirection() == Direction.Down)
                return new Rectangle((int)(float)pos.X, (int)(float)pos.Y, 10, 15);
            else
                return new Rectangle((int)(float)pos.X, (int)(float)pos.Y, 15, 10);
        }
        public override Rectangle getCollisionRectangle()
        {
            return getWorldRectangle();
        }
    }
}
