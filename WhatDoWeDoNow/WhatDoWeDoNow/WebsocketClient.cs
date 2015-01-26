using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;

namespace WhatDoWeDoNow
{
    public class WebsocketClient
    {
        WebSocket4Net.WebSocket websocket;
        public void Init()
        {
            
            websocket = new WebSocket("ws://localhost:2012/");
            websocket.Opened += new EventHandler(websocket_Opened);
            websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
            websocket.Closed += new EventHandler(websocket_Closed);
            websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            websocket.Open();
        }

        public void Send(string message)
        {
            websocket.Send(message);
        }

        public void SendChange(string change)
        {
            Send(
                Newtonsoft.Json.JsonConvert.SerializeObject(new JSON.PlayerChange(change))
            );
        }

        

        private void websocket_MessageReceived(object sender, EventArgs e)
        {
            string value = ((WebSocket4Net.MessageReceivedEventArgs)e).Message;
            dynamic d = JObject.Parse(value);
            if (d.Type == (new WhatDoWeDoNow.JSON.GameObjectPositionChange()).Type)
            {
                WhatDoWeDoNow.JSON.GameObjectPositionChange obj = JsonConvert.DeserializeObject<WhatDoWeDoNow.JSON.GameObjectPositionChange>(value);

                Microsoft.Xna.Framework.Vector2 pos = new Microsoft.Xna.Framework.Vector2((float)obj.X, (float)obj.Y);
                //TheGame.Instance.player1.setPos(pos);
                //TheGame.Instance.gameObjects[obj.Id].setPos(pos);
                GameObject gobj = TheGame.Instance.gameObjects.GetById(obj.Id);
                if (gobj != null)
                {
                    if (TheGame.Instance.distanceBetweenPoints(gobj.getPos(), pos) > 20)
                    {
                        gobj.setPos(pos);
                        Console.WriteLine("Distance corrected!");
                    }
                }
            }
            if (d.Type == (new WhatDoWeDoNow.JSON.GameObject()).Type)
            {
                WhatDoWeDoNow.JSON.GameObject obj = JsonConvert.DeserializeObject<WhatDoWeDoNow.JSON.GameObject>(value);

                TheGame.Instance.gameObjects.Add(obj.Id, GameObjectFactory.get(obj));
            }
            if (d.Type == (new WhatDoWeDoNow.JSON.GameObjectYouAre()).Type)
            {
                WhatDoWeDoNow.JSON.GameObjectYouAre obj = JsonConvert.DeserializeObject<WhatDoWeDoNow.JSON.GameObjectYouAre>(value);

                //TheGame.Instance.playerMe = (PlayerMe)TheGame.Instance.gameObjects.GetById(obj.Id);
                createPlayerMeAndTransformIt(obj.Id);
            }
        }

        private void createPlayerMeAndTransformIt(int id)
        {
            PlayerOther playerOther = (PlayerOther)TheGame.Instance.gameObjects.GetById(id);

            PlayerMe playerMe = new PlayerMe(playerOther.getPos(),
                new Microsoft.Xna.Framework.Vector2(playerOther.getCollisionRectangle().Width, playerOther.getCollisionRectangle().Height));


            //delete it first? meh! i think it works.

            TheGame.Instance.playerMe = playerMe;
            TheGame.Instance.gameObjects[id] = playerMe;
        }

        void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Websocket OPENED");
            //websocket.Send("Hello World!");
        }
        private void websocket_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Websocket ERROR");
        }

        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Websocket CLOSED");
            WebSocket4Net.WebSocket ws = (WebSocket4Net.WebSocket)sender;

            if (ws.State == WebSocketState.Closed)
            {
                Console.WriteLine("Websocket CLOSED - probably because the server is OFFLINE");
            }
        }
    }
}
