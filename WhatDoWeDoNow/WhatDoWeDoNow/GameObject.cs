using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public abstract class GameObject
    {
        public GameObjectType Type;
        //maintenance
        public bool isActive = true;
        public bool isInitialized = false;

        bool _isColidable = true;

        //position
        protected Vector2 pos;
        protected Rectangle dimensions;

        public GameObject(Vector2 pos, Rectangle dimensions, GameObjectType type)
        {
            this.pos = pos;
            this.dimensions = dimensions;

            Type = type;
        }

        public GameObject(Vector2 pos, Vector2 dimensions, GameObjectType type)
        {
            this.pos = pos;
            this.dimensions = new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y);

            Type = type;
        }

        public virtual void Draw(SpriteBatch spriteBatch, bool takeIntoConsiderationTheMapPos) { }
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public abstract void LoadContent(GraphicsContentLoader graphicsContentLoader);

        public virtual bool isColidable()
        {
            return _isColidable;
        }

        public void setCollidable(bool isIt)
        {
            _isColidable = isIt;
        }

        public void markAsColidable()
        {
            _isColidable = true;
        }
        public void markAsTransparent()
        {
            _isColidable = false;
        }


        public Rectangle getWorldRectangle()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, dimensions.Width, dimensions.Height);
        }
        public virtual Rectangle getCollisionRectangle()
        {
            return getWorldRectangle();
        }

        public Vector2 getPos()
        {
            return this.pos;
        }


        public virtual void setPos(Vector2 v2)
        {
            pos = v2;
        }

        public void setPosX(float x)
        {
            setPos(new Vector2(x, getPos().Y));
        }

        public void setPosY(float y)
        {
            setPos(new Vector2(getPos().X, y));
        }

        public void addPosX(float x)
        {
            setPos(new Vector2(getPos().X + x, getPos().Y));
        }

        public void setWidth(float width)
        {
            this.dimensions.Width = (int)width;
        }
        public void setHeight(float height)
        {
            this.dimensions.Height = (int)height;
        }
        

        /*
        protected Rectangle getWorldRectangleAdjusted(int x, int y, int width, int height)
        {
            Rectangle rect = getWorldRectangle();

            rect.X += x;
            rect.Y += y;
            rect.Width -= width;
            rect.Height -= height;

            return rect;
        }
         */
    }
}
