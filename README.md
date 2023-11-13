# Walking-Game

The Walking Game is an API where you can create a map (X, Y matrix), add characters to it, and move them around the map.

<p align="center">
  <img width="250" height="250" src="https://github.com/fravalpin/Walking-Game/blob/main/WalkGame.jpg?raw=true">
</p>

## Execution

It is developed with .NET C# 6, and to run it, you only need to have installed the SDK (https://dotnet.microsoft.com/es-es/download/dotnet/6.0) and execute it in the console, **within the WalkGameService** folder

    dotnet run

## Instructions

First, you need to start a new game:

#### POST /game 

    {
      "width": 1,  
      "height": 1    
    }

It will respond with an error if either of the two values is less than one.

---

To add a new character to the map:
#### POST /player
    {
      "username": "TheBestPlayer"
    }
It will return the position where it appears.
    {
      "position": {
        "row": 0,
        "column": 0
      }
    }

---

To move a character on the map:
#### PATCH /player/TheBestPlayer
    [
      {
        "operationType": 0,
        "path": "/Position",
        "op": "replace",
        "from": "string",
        "value": {"Row": 0, "Column": 1}
      }
    ]

If the position is valid, it returns the position where it is located.

    {
      "position": {
        "row": 0,
        "column": 1
      }
    }

---

To view information about a character:

#### GET /player?username=TheBestPlayer

Among other things, it will return the complete path that the character has taken.

    {
      "player": {
        "positions": [
          {
            "row": 0,
            "column": 0
          },
          {
            "row": 0,
            "column": 1
          }
        ],
        "position": {
          "row": 0,
          "column": 1
        },
        "username": " TheBestPlayer "
      }

---

To delete a character:

#### DELETE /player

    {
      "username": "TheBestPlayer"
    }
It returns
    {
      "message": "Player TheBestPlayer was deleted."
    }

---

To view information about the current number of players and their paths:

#### GET /game

It returns

    {
      "currentPlayers": 2,
      "players": [   
        {
          "positions": [
            {
              "row": 0,
              "column": 0
            }
          ],
          "position": {
            "row": 0,
            "column": 1
          },
          "username": "TheBesPlayer"
        },
        {
          "positions": [
            {
              "row": 1,
              "column": 1
            }
          ],
          "position": {
            "row": 0,
            "column": 0
          },
          "username": "SecondPlayer"
        }
      ]
    }
