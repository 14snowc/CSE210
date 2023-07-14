using System;

class Program
{
    static void Main(string[] args)
    {
        var Keyboard = new Keyboard();
        Keyboard.AddKey(char.Parse("w"), "up");
        Keyboard.AddKey(char.Parse("a"), "left");
        Keyboard.AddKey(char.Parse("s"), "down");
        Keyboard.AddKey(char.Parse("d"), "right");
        Keyboard.AddKey(char.Parse("e"), "shoot");
        var userOptions = new List<int>{
            7,
            7,
            2,
            5
        }; //Length, Width, Trap count, Slide count

        MainMenu(userOptions, Keyboard);
    }
    static void MainMenu(List<int> userOptions, Keyboard keyboard)
    {
        var menuItems = new List<string>{
            "Play",
            "How to play",
            "Game Settings",
            "Controls",
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
                GameplayLoop(userOptions, keyboard);
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
                //Controls
                Controls(keyboard);
            }
            else if(userChoice == 4)
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
    static void Controls(Keyboard keyboard)
    {
        List<string> options = new List<string>{
            "up",
            "down",
            "left",
            "right",
            "shoot",
            "unbind"
        };
        while(true)
        {
            Console.Clear();
            keyboard.ListKeys();
            Console.Write("Type \"yes\" to modify the controls ");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "yes")
            {
                Console.Write("Enter the key you wish to modify: ");
                char userKey = Console.ReadKey().KeyChar;
                
                int line_number = 1;
                foreach(var option in options)
                {
                    Console.WriteLine($"{line_number}) {option}");
                    line_number ++;
                }
                Console.Write($"Enter the function number to bind to {userKey}");
                try
                {
                    int userSelection = int.Parse(Console.ReadLine()) -1;
                    keyboard.AddKey(userKey, options[userSelection]);
                }
                catch
                {
                    Console.Write("Invalid input");
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
                return;
        }
    }
    static void GameplayLoop(List<int> Options, Keyboard keyboard)
    {
        var floor = new Floor(Options);
        bool isPlaying = true;
        bool canShoot = true;
        string roomStatus;
        var userShotGuess = new List<int>(); 
        while(isPlaying)
        {
            string message;
            if(canShoot)
                message = "Take a shot when you think you know where the dragon is. ";
            else
                message = "Find the arrow and take a shot at the dragon.";
            floor.displayRooms(true);
            roomStatus = floor.MovePlayer(GetUserActionInt(message, userShotGuess, canShoot, keyboard));
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
            else if(roomStatus == "arrow" && !canShoot)
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
        Console.ReadKey();
    }
    static int GetUserActionInt(string message, List<int> userShoot, bool canShoot, Keyboard keyboard)
    {
        string  userInput;
        while(true)
        {
            Console.Write(message);
            userInput = keyboard.GetKeyPress();

            if(userInput == "up")
            {
                return 0;
            }
            else if(userInput == "right")
            {
                return 1;
            }
            else if(userInput == "down")
            {
                return 2;
            }
            else if(userInput == "left")
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