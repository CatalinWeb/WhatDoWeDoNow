using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public static class GameObjectFactory
    {
        //player
        //other else

        
        /*
        public static GameObject GetGameObject<T>(int posX, int posY, int dimensionX, int dimensionY) where T: GameObject, new()
        {
            return new T(
                new Vector2(posX, posY),
                new Vector2(dimensionX, dimensionX));
        }
        */


        public static GameObject get(JSON.GameObject gameObject)
        {
            GameObject toReturn = null;
            switch(gameObject.GameObjectType) {
                case "Player":
                    toReturn = new PlayerOther(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "PlayerMe":
                    toReturn = new PlayerMe(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Bullet":
                    toReturn = new Bullet(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Gun":
                    toReturn = new Gun(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Guy":
                    toReturn = new Guy(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "GoodDoor":
                    toReturn = new GoodDoor(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "BadDoor":
                    toReturn = new BadDoor(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Door":
                    toReturn = new Door(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "ChoiceDoor":
                    toReturn = new ChoiceDoor(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Switch":
                    toReturn = new Switch(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Block":
                    toReturn = new Block(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Key":
                    toReturn = new Key(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                case "Platform":
                    toReturn = new Platform(new Vector2(gameObject.posX, gameObject.posY), new Vector2(gameObject.dimensionX, gameObject.dimensionX));
                    break;
                    

                default:
                    break;
            }

            return toReturn;
        }
        public static JSON.GameObject to(int id, GameObject GameObject)
        {
            JSON.GameObject gameObject = new JSON.GameObject {
                Id = id,
                posX = (int)GameObject.getPos().X,
                posY = (int)GameObject.getPos().Y,
                dimensionX = GameObject.getCollisionRectangle().Width,
                dimensionY = GameObject.getCollisionRectangle().Height,
                GameObjectType = GameObject.Type.ToString()
            };

            return gameObject;
        }

    }
}
