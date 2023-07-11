using System;

class Program
{
    static void Main(string[] args)
    {
        var userOptions = new List<int>{
            6,
            6,
            0,
            5
        }; //Length, Width, Trap count, Slide count

        MainMenu(userOptions);
    }

    static void MainMenu(List<int> userOptions)
    {
        var menuItems = new List<string>{
            "Play",
            "How to play",
            "Options",
            "Quit"
        };
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Dragon Hunt");
            int userChoice = DisplayMenu(menuItems);
            if(userChoice == 0)
            {
                //Play
                GameplayLoop(userOptions);
            }
            else if(userChoice == 1)
            {
                //how to play
                Tutorial();
            }
            else if(userChoice == 2)
            {
                //Options
                Options(userOptions);
            }
            else if(userChoice == 3)
            {
                //Quit
                return;
            }
            Thread.Sleep(2000);
        }
    }
    static int DisplayMenu(List<string> menuItems)
    {
        
        while(true)
        {

            int itemNumber = 1;
            foreach(var menuItem in menuItems)
            {
                Console.WriteLine($" {itemNumber}) {menuItem}");
                itemNumber ++;
            }
            Console.Write("Please enter your selection: ");
            try
            {    
                int userChoice = int.Parse(Console.ReadLine()) -1;
                if(userChoice < menuItems.Count() && userChoice >= 0)
                    return userChoice;
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.Clear();
                }    
            }
            catch
            {
                Console.WriteLine("Invalid input.");
                Console.Clear();
            }
        }
    }
    static void Tutorial()
    {
        Console.Clear();
        Console.WriteLine("The objective:\n 1) Avoid hazards like traps and the dragon.\n 2) Find the arrow hidden in a room.\n 3) Take a shot at the room the dragon is in.");
        Continue();

        Console.Clear();
        Console.WriteLine("The room you are in is displayed like this:\n [ } ]\nRooms you have explored will have brackets\n [  ]\nBut rooms you have not explored will have lines\n |   |");
        Continue();

        Console.Clear();
        Console.WriteLine("-Trap rooms-\n Trap rooms will make a marking 1 tile away\n [x  ]\n If you move into a trap room you will get a game over. Avoid at all costs.\n");
        Console.WriteLine("[   ][x ][   ]\n[x  ][trp][x  ]\n[   ][x  ][   ]");
        Continue();

        Console.Clear();
        Console.WriteLine("-Dragon Room-\n There is only 1 dragon room and it leaves warnings up to 2 tiles away\n [  #]\n If you move into the dragon room you will get a game over\n Once you get an arrow take a shot at the room you think the dragon is in.");
        Console.WriteLine("[   ][   ][  #][   ][   ]\n[   ][  #][  #][  #][   ]\n[  #][  #][drg][  #][  #]\n[   ][  #][  #][  #][   ]\n[   ][   ][  #][   ][   ]");
        Continue();

        Console.Clear();
        Console.WriteLine("-Arrow Room-\n There is only 1 arrow room, after entering it you will be able to take a shot at the dragon.\n Make sure that you know the location of the dragon because if you miss its game over.");
        Continue();

        Console.Clear();
        Console.WriteLine("-Slide Rooms-\n There are multiple slide rooms, these rooms redirect warnings and player movement into a neighboring room.\n They come in 3 types:\n [ \\ ]: Redirects North to East, South to West and vise versa\n [-|-]: Continues in the direction\n [ / ]: Redirects North to West, South to East and vise versa");
        Console.WriteLine("These rooms are dangerous as they spread confusion.\n[x  ][ \\ ][   ]\n[x  ][trp][x  ]\n[   ][x  ][   ]");
        Continue();

        Console.Clear();
        Console.WriteLine("Try to guess what tile has the dragon hidden in the unexplored tiles, be aware of potentual slides.");
        Console.WriteLine("|   |[  #]|   ||   ||   ||   |\n|   ||   ||   ||   ||   ||   |\n|   ||   |[  #]|   ||   ||   |\n[  #][  #][  #][  #]|   ||   |\n[  #]|   ||   ||   ||   |[  #]\n[  #][  #][  #]|   ||   ||   |");
        Continue();

        Console.Clear();
        Console.WriteLine("The dragon was in row 5, Column 2, did you guess right?");
        Console.WriteLine("[   ][  #][   ][-|-][   ][   ]\n[   ][   ][-|-][   ][   ][   ]\n[   ][ / ][  #][   ][   ][   ]\n[  #][  #][  #][  #][   ][   ]\n[  #][Drg][ / ][   ][   ][  #]\n[  #][  #][  #][-|-][   ][   ]");
        Continue();
    }
    static void Continue()
    {
        Console.Write("\n\n<Enter to continue>");
        Console.ReadLine();
    }
    static List<int> Options(List<int> userOptions)
    {
        var optionItems = new List<string>{
            "Length",
            "Width",
            "Trap rooms",
            "Slide rooms",
            "Back"
        };
        while(true)
        {
            int userChoice = DisplayMenu(optionItems);
            if(userChoice == 4)
                return userOptions;
            try
            {
                Console.WriteLine($" {optionItems[userChoice]}: {userOptions[userChoice]}");
                Console.Write("Enter a new number: ");
                int userOptionChoice = int.Parse(Console.ReadLine());
                userOptions[userChoice] = userOptionChoice;
            }
            catch
            {
                Console.WriteLine("Invalid input");
            }
        }    
    }

    static void GameplayLoop(List<int> Options)
    {
        var floor = new Floor(Options);
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
                isPlaying = false;
                Thread.Sleep(2000);
            }
            else if(roomStatus == "hit")
            {
                Console.WriteLine("After a but, you hear the unmistakeable sound of a dragon roar, then silence. You head into the room you sent the arrow into, and found the arrow had pierced the dragons heart. You are a hero, the village is safe now.\n Game End: The village Hero");
                isPlaying = false;
                Thread.Sleep(2000);
            }
        }
        floor.displayRooms(true);
        Console.ReadLine();
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