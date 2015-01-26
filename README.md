# WhatDoWeDoNow
The game for What do we do now challenge for Game Jam 2015

**If you want to see how the server works:**

1. Run the server
2. Modify `Game1.cs` line 46 from `game = new GameSinglePlayer();` to `game = new GameMultiPlayer();` and run the game
3. Go in the folder where the game compiled (eg. WhatDoWeDoNow\WhatDoWeDoNow\bin\x86\Debug) and run WhatDoWeDoNow.exe multiple times to simulate different players playing at the same time.
4. Optional: If you want to play the game from more than 1 machine, go to `WebsocketClient.cs` and modify the IP from line 18 to connect to whatever the server's IP is. You don't have to change anything in the server. Just run the clients now.
