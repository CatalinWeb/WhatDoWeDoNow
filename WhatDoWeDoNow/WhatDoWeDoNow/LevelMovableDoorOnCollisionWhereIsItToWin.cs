using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class LevelMovableDoorOnCollisionWhereIsItToWin : Level
    {
        int movedXTimes = 0;


        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (TheGame.Instance.getPlayer().getCollisionRectangle().Intersects(TheGame.Instance.door.getCollisionRectangle()))
            {
                switch (movedXTimes)
                {
                    case 0:
                        TheGame.Instance.door.setPosX(0);
                        break;
                    case 1:
                        TheGame.Instance.door.setPosX(800);
                        break;
                    case 2:
                        TheGame.Instance.door.setPosX(400);
                        break;
                    case 3:
                        TheGame.Instance.door.setPosX(0);
                        break;
                    case 4:
                        TheGame.Instance.door.setPosX(800);/*
                        break;
                    case 5:
                        TheGame.Instance.door.setPosX(400);
                        break;
                    case 6:
                        TheGame.Instance.door.setPosX(300);
                        break;
                    case 7:
                        TheGame.Instance.door.setPosX(0);
                        break;
                    case 8:
                        TheGame.Instance.door.setPosX(800);
                        break;
                    case 9:
                        TheGame.Instance.door.setPosX(400);
                        break;
                    case 10:
                        TheGame.Instance.door.setPosX(300);
                        break;
                    case 11:
                        TheGame.Instance.door.setPosX(0);
                        break;
                    case 12:
                        TheGame.Instance.door.setPosX(300);
                        break;
                    case 13:
                        TheGame.Instance.door.setPosX(500);
                        break;
                    case 14:
                        TheGame.Instance.door.setPosX(800);
                        break;
                    case 15:
                        TheGame.Instance.door.setPosX(0);
                        break;
                    case 16:
                        TheGame.Instance.door.setPosX(800);
                        break;
                    case 17:
                        TheGame.Instance.door.setPosX(400);
                        break;
                    case 18:
                        TheGame.Instance.door.setPosX(300);
                        break;
                    case 19:
                        TheGame.Instance.door.setPosX(0);*/
                        break;
                    case 5:
                        TheGame.Instance.door.setPosX(TheGame.Instance.map.Size.X - TheGame.Instance.door.getCollisionRectangle().Width - 5);
                        TheGame.Instance.door.setPosY(TheGame.Instance.door.getPos().Y - 125);
                        break;

                    default:
                        markAsComplete();
                        break;
                }
                

                movedXTimes++;
            }
        }
    }
}
