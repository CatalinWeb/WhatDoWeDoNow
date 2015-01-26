using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDoWeDoNow
{
    public class GameObjects : Dictionary<int, GameObject>
    {
        int maxIdAdded = -1;
        public GameObjects()
        {

        }

        public void AddGameObject(GameObject gameObject)
        {

            Add(getNextId(), gameObject);
        }

        private int getNextId()
        {
            int a = ++maxIdAdded;
            int b = Count;

            return Math.Max(a, b) + 2; // this is bad but works for now

        }


        public void RemoveGameObject(GameObject gameObject)
        {
            foreach (var item in this.Where(kvp => kvp.Value == gameObject).ToList())
            {
                this.Remove(item.Key);
            }

            /*
            for (int i = TheGame.Instance.gameObjects.Count - 1; i >= 0; i--)
            {
                if (TheGame.Instance.gameObjects[i] == TheGame.Instance.door)
                    TheGame.Instance.gameObjects.RemoveAt(i);
            }*/
        }

        public int getIdFor(GameObject gameObject)
        {
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                GameObject gameObject2 = keyValuePair.Value;
                if (gameObject == gameObject2)
                    return keyValuePair.Key;
            }

            return -1;
        }

        public GameObject GetById(int id)
        {
            foreach (KeyValuePair<int, GameObject> keyValuePair in TheGame.Instance.gameObjects)
            {
                if (keyValuePair.Key == id)
                    return keyValuePair.Value;
            }

            return null;
        }
    }
}
