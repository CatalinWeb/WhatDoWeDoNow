using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelCollideWith2KeysAndCollideWithGuy : Level
    {
        Key key1;
        Key key2;

        bool key1Taken = false;
        bool key2Taken = false;
        public LevelCollideWith2KeysAndCollideWithGuy()
            : base()
        {
        }

        public override void Initialize()
        {
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject = keyValuePair.Value;
                gameObject.addPosX(TheGame.Instance.map.Size.X);
            }

            key1 = new Key(
                    new Vector2(TheGame.Instance.map.Size.X - 500, 400),
                    new Vector2(100, 100));

            key2 = new Key(
                    new Vector2(TheGame.Instance.map.Size.X * 2 + 500, 400),
                    new Vector2(100, 100));


            TheGame.Instance.map.Pos = new Microsoft.Xna.Framework.Vector2(TheGame.Instance.map.Size.X, 0);
            TheGame.Instance.map.Size = new Microsoft.Xna.Framework.Vector2(TheGame.Instance.map.Size.X * 3, TheGame.Instance.map.Size.Y);


            TheGame.Instance.gameObjects.AddGameObject(key1);
            TheGame.Instance.gameObjects.AddGameObject(key2);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(key1.getCollisionRectangle()))
            {
                key1Taken = true;
                key1.PickedUp();
            }

            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(key2.getCollisionRectangle()))
            {
                key2Taken = true;
                key2.PickedUp();
            }

            if (key1Taken == true && key2Taken == true && TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.guy.getCollisionRectangle()))
            {
                markAsComplete();
            }
        }
    }
}
