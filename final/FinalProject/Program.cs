using System;

class Program
{
    static void Main(string[] args)
    {
        GameplayLoop();
    }

    static void GameplayLoop()
    {
        var floor = new Floor(7, 7);
        bool isPlaying = true;
        bool canShoot = false;
        string roomStatus;
        var userShotGuess = new List<int>(); 
        while(isPlaying)
        {
            string message = "Type a direction(n, e, s, w) to move. \n ";
            if(canShoot)
                message += "Type \"shoot\" when you think you know where the dragon is. ";
            else
                message += "Find the arrow and take a shot at the dragon.";
            floor.displayRooms();
            roomStatus = floor.MovePlayer(GetUserActionInt(message, userShotGuess, canShoot));
            if(roomStatus == "trap")
            {
                floor.displayRooms();
                Thread.Sleep(1000);
                Console.WriteLine("GameOver: Trap");
                Thread.Sleep(2000);
                isPlaying = false;
            }
            else if(roomStatus == "dragon")
            {
                floor.displayRooms();
                Thread.Sleep(1000);
                Console.WriteLine("GameOver: Dragon");
                Thread.Sleep(2000);
                isPlaying = false;
            }
            else if(roomStatus == "arrow")
            {
                Console.Clear();
                Console.WriteLine("You found the Arrow.\n You can now take a shot at the dragon, but dont miss. ");
                canShoot = true;
                Thread.Sleep(2000);
            }
            else if(roomStatus == "miss")
            {
                Console.WriteLine("After a bit, you begin to hear noises behind you. Your blood runs cold as you slowly turn to face the dragon. The arrow must have been sent to the wrong room, not only leaving you defenceless but also waking up the dragon.\n Game Over: Missed the shot");
            }
            else if(roomStatus == "hit")
            {
                Console.WriteLine("After a but, you hear the unmistakeable sound of a dragon roar, then silence. You head into the room you sent the arrow into, and found the arrow had pierced the dragons heart. You are a hero, the village is safe now.\n Game End: The village Hero");
            }
        }
        floor.displayRooms(true);
    }
    static int GetUserActionInt(string message, List<int> userShoot, bool canShoot)
    {
        string  userInput;
        while(true)
        {
            Console.Write(message);
            userInput = Console.ReadLine().ToLower();

            if(userInput == "north" || userInput == "n")
            {
                return 0;
            }
            else if(userInput == "east" || userInput == "e")
            {
                return 1;
            }
            else if(userInput == "south" || userInput == "s")
            {
                return 2;
            }
            else if(userInput == "west" || userInput == "w")
            {
                return 3;
            }
            else if(userInput == "shoot" && canShoot)
            {
                return 4;
            }
        }
    }
}