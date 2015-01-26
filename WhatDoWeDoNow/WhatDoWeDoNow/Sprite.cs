using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Sprite : GameObject
    {
        Texture2D texture;

        int columns;
        int currentColumn;
        int rows;
        int currentRow;

        int timeBetweenAnimationsInMilliseconds;

        double lastUpdateTime = 0.0;

        Vector2 sourceDimensions;

        bool _fixed = false;
        int fixedAtRow;
        int fixedAtColumn;

        public Sprite(Vector2 pos, Vector2 dimensions, Vector2 sourceDimensions, int colomns, int rows, int timeBetweenAnimationsInMilliseconds = 60)
            : base(pos, dimensions, GameObjectType.Other)
        {
            this.timeBetweenAnimationsInMilliseconds = timeBetweenAnimationsInMilliseconds;
            this.columns = colomns;
            this.rows = rows;
            currentColumn = 0;
            currentRow = 0;
            this.sourceDimensions = sourceDimensions;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (texture == null) return;

            int column;
            int row;

            if (_fixed)
            {
                column = fixedAtColumn;
                row = fixedAtRow;
            }
            else
            {
                column = currentColumn;
                row = currentRow;
            }


            Rectangle rect1 =
                new Rectangle((int)getPos().X, (int)getPos().Y, dimensions.Width, dimensions.Height);
            rect1.X -= (int)TheGame.Instance.map.Pos.X;
            Rectangle rect2 =
                new Rectangle(column * (int)this.sourceDimensions.X, row * (int)this.sourceDimensions.Y, dimensions.Width, dimensions.Height);
            spriteBatch.Draw(texture,rect1, rect2,
                Color.White);
        }





        public void setRow(int row)
        {
            this.currentRow = row;
        }
        public void setColumn(int column)
        {
            this.currentColumn = column;
        }

        public void fix(int row, int column)
        {
            fixedAtRow = row;
            fixedAtColumn = column;
            _fixed = true;
        }
        public void unfix()
        {
            fixedAtRow = fixedAtColumn = -1;
            _fixed = false;
        }

        void update()
        {
            if (_fixed == true) { return; }

            currentColumn++;
            if (currentColumn >= columns)
                currentColumn = 0;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds - lastUpdateTime > timeBetweenAnimationsInMilliseconds)
            {
                update();
                lastUpdateTime = gameTime.TotalGameTime.TotalMilliseconds;
            }

        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            texture = graphicsContentLoader.Get("Characters");
            isInitialized = true;
        }
    }
}
