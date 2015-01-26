using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Player1 : Player
    {
        public Player1(Vector2 pos, Vector2 dimensions) : base(pos, dimensions)
        {

        }
        
        public override void UpdateControl(KeyboardStateCustom keyboardState)
        {
            if (keyboardState.IsKeyDown(KeysMe.Player1Up))
                playerUpCommand();
            else
                playerUpCommandEnd();

            if (keyboardState.IsKeyDown(KeysMe.Player1Down))
                playerDownCommand();
            else
                playerDownCommandEnd();


            if (keyboardState.IsKeyDown(KeysMe.Player1Left))
                playerLeftCommand();
            else
                playerLeftCommandEnd();


            if (keyboardState.IsKeyDown(KeysMe.Player1Right))
                playerRightCommand();
            else
                playerRightCommandEnd();

            if (keyboardState.IsKeyDown(KeysMe.Player1Jump))
                playerJumpCommand();
            else
                playerJumpCommandEnd();

            if(HasGun())
            if (keyboardState.IsKeyDown(KeysMe.Player1Fire))
            {
                playerFireCommand();
            }

            this.UpdatePositionToAllPCs();
        }
    }
}
