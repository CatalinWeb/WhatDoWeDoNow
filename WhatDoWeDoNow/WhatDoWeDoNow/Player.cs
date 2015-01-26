using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public abstract class Player : GameObject
    {
        /*
        bool isJumping = false;
        bool isInAir = false;
        bool isSpaceAvailable = true;
        float acceleration;*/
        //acceleration = 0.1f;

        bool _male = true;

        bool _hasGun = false;

        float jumpHigh;

        bool _isDead = false;

        public Direction playerDirection;
        protected Vector2 velocity;
        protected float vel;
        protected Vector2 jumpPos;
        protected bool jumpedBla = false;
        protected bool jumpingAnimationFinished = false;


        public Sprite sprite;

        public Player(Vector2 pos, Vector2 dimensions) : base(pos, dimensions, GameObjectType.Player)
        {
            velocity = new Vector2(0, 0);
            vel = 15;
            jumpHigh = 160.0f;
            jumpPos = Vector2.Zero;
            markAsTransparent();

            //sprite = new Sprite(pos, new Vector2(130, 130), 8, 8);
            //sprite = new Sprite(pos, new Vector2(getCollisionRectangle().Width, getCollisionRectangle().Height), new Vector2(130, 130), 8, 8);
            sprite = new Sprite(pos, new Vector2(55, 130), new Vector2(55, 130), 8, 8);
        }


        public override void Update(GameTime gameTime)
        {
            UpdateForCollisions(gameTime);

            sprite.Update(gameTime);

            if (isMale())
            {
                if (playerDirection == Direction.Right)
                    sprite.setRow(0);
                if (playerDirection == Direction.Left)
                    sprite.setRow(1);

                if (!isGoingLeft && !isGoingRight && jumpPos.Y == 0.0f)
                    sprite.fix(4, 0);
                else
                    sprite.unfix();
            }
            else 
            {
                if (playerDirection == Direction.Right)
                    sprite.setRow(2);
                if (playerDirection == Direction.Left)
                    sprite.setRow(3);

                if (!isGoingLeft && !isGoingRight && jumpPos.Y == 0.0f)
                    sprite.fix(4, 4);
                else
                    sprite.unfix();
            }

        }

        private void UpdateForCollisions(GameTime gameTime)
        {
            if (velocity.Y == 0)
                velocity.Y = vel; // gravity.


            if (isGoingLeft && isGoingRight) //both ?! NO!
            {

            }
            else
            {
                if (isGoingLeft)
                {
                    velocity.X = -vel;
                }
                if (isGoingRight)
                {
                    velocity.X = vel;
                }
            }

            //velocity *= (float)gameTime.ElapsedGameTime.TotalSeconds;

            bool breakItAll;

            breakItAll = false;
            //bottom
            if (velocity.Y > 0)
            {
                for (int i = 1; i <= (int)velocity.Y; i++)
                {
                    pos.Y += 1;

                    foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
                    {
                        GameObject gameObject = keyValuePair.Value;
                        if (gameObject == this) continue;

                        if (gameObject.getCollisionRectangle().Intersects(getCollisionRectangle()) && gameObject.isColidable())
                        {
                            pos.Y -= 1;
                            velocity.Y = 0;
                            breakItAll = true;
                            jumpingAnimationFinished = true;
                            break;
                        }
                    }

                    if (breakItAll) break;
                }
            }

            breakItAll = false;
            if (velocity.Y < 0)
            {
                for (int i = 1; i <= -(int)velocity.Y; i++)
                {
                    pos.Y += -1;

                    foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
                    {
                        GameObject gameObject = keyValuePair.Value;
                        if (gameObject == this) continue;

                        if (gameObject.getCollisionRectangle().Intersects(getCollisionRectangle()) && gameObject.isColidable())
                        {
                            pos.Y -= -1;
                            velocity.Y = 0;
                            breakItAll = true;
                            jumpingAnimationFinished = true;
                            break;
                        }
                    }

                    if (breakItAll) break;
                }
            }

            breakItAll = false;
            if (velocity.X > 0)
            {
                for (int i = 1; i <= (int)velocity.X; i++)
                {
                    pos.X += 1;

                    foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
                    {
                        GameObject gameObject = keyValuePair.Value;
                        if (gameObject == this) continue;

                        if (gameObject.getCollisionRectangle().Intersects(getCollisionRectangle()) && gameObject.isColidable())
                        {
                            pos.X -= 1;
                            velocity.X = 0;
                            breakItAll = true;
                            break;
                        }
                    }

                    if (breakItAll) break;
                }

                velocity.X = 0;
            }

            breakItAll = false;
            if (velocity.X < 0)
            {
                for (int i = 1; i <= -(int)velocity.X; i++)
                {
                    pos.X += -1;

                    foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
                    {
                        GameObject gameObject = keyValuePair.Value;
                        if (gameObject == this) continue;

                        if (gameObject.getCollisionRectangle().Intersects(getCollisionRectangle()) && gameObject.isColidable())
                        {
                            pos.X -= -1;
                            velocity.X = 0;
                            breakItAll = true;
                            break;
                        }
                    }

                    if (breakItAll) break;
                }

                velocity.X = 0;
            }



            //jumped to high? go back.
            if (pos.Y <= jumpPos.Y - jumpHigh)
            {
                jumpPos = Vector2.Zero;

                velocity.Y *= -1;
            }

            setPos(pos);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public override void LoadContent(GraphicsContentLoader graphicsContentLoader)
        {
            sprite.LoadContent(graphicsContentLoader);
        }

        public abstract void UpdateControl(KeyboardStateCustom keyboardState);



        public Vector2 lastPositionTransmitted;
        public void UpdatePositionToAllPCs()
        {
            /*
            return;


            if (TheGame.Instance.websocketClient != null)
            {
                if (lastPositionTransmitted == getPos()) return;

                TheGame.Instance.websocketClient.Send(
                    TheGame.Instance.makeGameobjectPositionChangeFromVector2(getPos())
                );

                lastPositionTransmitted = getPos();
            }*/
        }


#region networking


        public bool isGoingDown = false;
        public bool isGoingUp = false;
        public bool isGoingLeft = false;
        public bool isGoingRight = false;
        public bool isGoingDownServer = false;
        public bool isGoingUpServer = false;
        public bool isGoingLeftServer = false;
        public bool isGoingRightServer = false;

        public void playerDownCommand()
        {
            isGoingDown = true;
            if (TheGame.Instance.isMultiPlayer() && isGoingDown != isGoingDownServer)
            {
                TheGame.Instance.websocketClient.SendChange("Down");
                isGoingDownServer = !isGoingDownServer;
            }

            playerDirection = Direction.Down;
        }
        public void playerDownCommandEnd()
        {
            if (isGoingDown == false) return;
            if (TheGame.Instance.isMultiPlayer() && isGoingDown != isGoingDownServer)
            {
                TheGame.Instance.websocketClient.SendChange("DownEnd");
                isGoingDownServer = !isGoingDownServer;
            }

            playerDirection = Direction.Down;
        }


        public void playerUpCommand()
        {
            if (isGoingUp == true) return;
            isGoingUp = true;
            if (TheGame.Instance.isMultiPlayer() && isGoingUp != isGoingUpServer)
            {
                TheGame.Instance.websocketClient.SendChange("Up");
                isGoingUpServer = !isGoingUpServer;
            }

            playerDirection = Direction.Up;
        }
        public void playerUpCommandEnd()
        {
            if (isGoingUp == false) return;
            isGoingUp = false;
            if (TheGame.Instance.isMultiPlayer() && isGoingUp != isGoingUpServer)
            {
                TheGame.Instance.websocketClient.SendChange("UpEnd");
                isGoingUpServer = !isGoingUpServer;
            }

            playerDirection = Direction.Up;
        }


        public void playerLeftCommand()
        {
            if (isGoingLeft == true) return;
            //Console.WriteLine("playerLeftCommand()");

            isGoingLeft = true;
            if (TheGame.Instance.isMultiPlayer() && isGoingLeft != isGoingLeftServer)
            {
                TheGame.Instance.websocketClient.SendChange("Left");
                isGoingLeftServer = !isGoingLeftServer;
            }
            else
            {
            }
            //velocity.X = -vel;
            playerDirection = Direction.Left;
        }
        public void playerLeftCommandEnd()
        {
            if (isGoingLeft == false) return;
            //Console.WriteLine("playerLeftCommandEnd()");
            isGoingLeft = false;
            if (TheGame.Instance.isMultiPlayer() && isGoingLeft != isGoingLeftServer)
            {
                TheGame.Instance.websocketClient.SendChange("LeftEnd");
                isGoingLeftServer = !isGoingLeftServer;
            }
            else
            {
            }
            //velocity.X = Math.Max(0, velocity.X);
            playerDirection = Direction.Right;
        }


        public void playerRightCommand()
        {
            if (isGoingRight == true) return;
            isGoingRight = true;
            if (TheGame.Instance.isMultiPlayer() && isGoingRight != isGoingRightServer)
            {
                TheGame.Instance.websocketClient.SendChange("Right");
                isGoingRightServer = !isGoingRightServer;
            }
            else
            {
            }

            //velocity.X = vel;
            playerDirection = Direction.Right;
        }
        public void playerRightCommandEnd()
        {
            if (isGoingRight == false) return;
            isGoingRight = false;
            if (TheGame.Instance.isMultiPlayer() && isGoingRight != isGoingRightServer)
            {
                TheGame.Instance.websocketClient.SendChange("RightEnd");
                isGoingRightServer = !isGoingRightServer;
            }
            else
            {
            }

            //velocity.X = Math.Min(velocity.X, 0);
            playerDirection = Direction.Left;
        }



        private bool wasJumped = false;

        public void playerJumpCommand()
        {
            if (TheGame.Instance.isMultiPlayer())
            {
                TheGame.Instance.websocketClient.SendChange("Jump");
                wasJumped = true;
            }

            if (velocity.Y == 0 && jumpedBla == true)
            {
                TheGame.Instance.playSound("Jump");
                //jump here
                velocity.Y = -vel;

                jumpPos = pos;
                jumpedBla = false;
                jumpingAnimationFinished = false;
            }
        }
        public void playerJumpCommandEnd()
        {
            if (TheGame.Instance.isMultiPlayer())
            {
                if (wasJumped == true)
                {
                    TheGame.Instance.websocketClient.SendChange("JumpEnd");
                    wasJumped = false;
                }
            }
            if (jumpingAnimationFinished == true)
            {
                jumpedBla = true;
            }
        }






#endregion




        public void playerFireCommand()
        {
            TheGame.Instance.Fire(getPos() + new Vector2(getCollisionRectangle().Width / 2, getCollisionRectangle().Height / 2), playerDirection, 40.0f);
        }



        public override void setPos(Vector2 v2)
        {
            sprite.setPos(v2);
            base.setPos(v2);
        }

        public void makeFemale()
        {
            _male = false;
            sprite.setRow(2);
        }
        public void makeMale()
        {
            _male = true;
            sprite.setRow(0);
        }

        public bool isMale()
        {
            return _male == true;
        }

        public bool isFemale()
        {
            return !isMale();
        }



        public bool isDead()
        {
            return _isDead;
        }

        public void Die()
        {
            _isDead = true;
        }

        public void setJumpHigh(float jumpHigh)
        {
            this.jumpHigh = jumpHigh;
        }
        public float getJumpHigh()
        {
            return this.jumpHigh;
        }
        

        //gun
        public bool HasGun()
        {
            return _hasGun;
        }
        public void GiveGun()
        {
            _hasGun = true;
        }
        public void DropGun()
        {
            _hasGun = false;
        }

    }
}
