using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Level3SwitchesMatchCombination : Level
    {
        List<Switch> switches;
        Key key;
        bool hasTheKey = false;
        bool keyAdded = false;
        public Level3SwitchesMatchCombination() : base()
        {
            switches = new List<Switch>();
        }

        public override void Initialize()
        {
            Switch switch1, switch2, switch3;
            switch1 = new Switch(
                    new Vector2(300, 380),
                    new Vector2(25, 60));
            switches.Add(switch1);
            TheGame.Instance.gameObjects.AddGameObject(switch1);

            switch2 = new Switch(
                    new Vector2(420, 380),
                    new Vector2(25, 60));
            switches.Add(switch2);
            TheGame.Instance.gameObjects.AddGameObject(switch2);

            switch3 = new Switch(
                    new Vector2(550, 380),
                    new Vector2(25, 60));
            switches.Add(switch3);
            TheGame.Instance.gameObjects.AddGameObject(switch3);
        }

        public override void Update(GameTime gameTime)
        {
            if (switches[0].isON() && switches[1].isOFF() && switches[2].isON())
            {
                if (keyAdded == false)
                {
                    //add key
                    addKey();
                    keyAdded = true;
                }
            }
            else
            {

                if (key != null)
                {
                    TheGame.Instance.gameObjects.RemoveGameObject(key);
                    key = null;
                    hasTheKey = false;
                    keyAdded = false;
                }
            }

            if (key != null && key.getCollisionRectangle().Intersects(TheGame.Instance.getPlayer().getCollisionRectangle()))
            {
                hasTheKey = true;
                key.PickedUp();
            }

            if (hasTheKey && TheGame.Instance.door.getCollisionRectangle().Intersects(TheGame.Instance.getPlayer().getCollisionRectangle()))
            {
                markAsComplete();
            }
        }


        void addKey()
        {
            key = new Key(
                new Vector2(920, 400),
                new Vector2(100, 100));

            TheGame.Instance.gameObjects.AddGameObject(key);
        }


        KeyboardState oldKeyboardState;
        bool oldKeyboardStateInitialized = false;
        public override void UpdateControl(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Enter) && oldKeyboardStateInitialized == true && !oldKeyboardState.IsKeyDown(Keys.Enter))
            {
                foreach (Switch sw in switches)
                {
                    if (sw.playerIsHover)
                    {
                        sw.SWITCH();
                        //break;
                    }
                }
            }

            oldKeyboardState = keyboardState;
            oldKeyboardStateInitialized = true;
        }


    }
}
