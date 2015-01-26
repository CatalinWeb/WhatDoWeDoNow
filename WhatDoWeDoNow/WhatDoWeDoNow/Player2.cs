using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class Player2 : Player
    {
        public Player2(Vector2 pos, Vector2 dimensions)
            : base(pos, dimensions)
        {

        }

        public override void UpdateControl(KeyboardStateCustom keyboardState)
        {
            if (keyboardState.IsKeyDown(KeysMe.Player2Up))
                playerUpCommand();
            else
                playerUpCommandEnd();

            if (keyboardState.IsKeyDown(KeysMe.Player2Down))
                playerDownCommand();
            else
                playerDownCommandEnd();


            if (keyboardState.IsKeyDown(KeysMe.Player2Left))
                playerLeftCommand();
            else
                playerLeftCommandEnd();


            if (keyboardState.IsKeyDown(KeysMe.Player2Right))
                playerRightCommand();
            else
                playerRightCommandEnd();

            if (keyboardState.IsKeyDown(KeysMe.Player2Jump))
                playerJumpCommand();
            else
                playerJumpCommandEnd();

            this.UpdatePositionToAllPCs();
        }


    }
}
