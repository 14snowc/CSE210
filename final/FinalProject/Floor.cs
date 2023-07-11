class Floor
{
    private int _floorLength; //y
    private int _floorWidth; //x

    private Random _choice;
    private List<List<RoomBase>> _rooms;
    private List<RoomBase> _executableRooms;
    private RoomBase _playerRoom;


    public Floor(List<int> options)
    {
        _choice = new Random();
        _rooms = new List<List<RoomBase>>();
        _executableRooms = new List<RoomBase>();

        _floorLength = options[0];
        _floorWidth = options[1];
        var importantRooms = new List<List<int>>();
        int trapRooms = options[2];
        int slides = options[3];

        GenerateImportantRoomLocation(importantRooms, 0);//Starting Room, Arrow Room, Dragon Room, Trap Rooms, Slides
        GenerateImportantRoomLocation(importantRooms, 1);
        GenerateImportantRoomLocation(importantRooms, 2);
        for (int i = 0; i < trapRooms; i++)  
        {
            //Get the Starting Room
            GenerateImportantRoomLocation(importantRooms, 3);
        }
        for (int i = 0; i < slides; i++)  
        {
            GenerateImportantRoomLocation(importantRooms, 4);
        }

        for (int y = 0; y < _floorLength; y++)
        {
            _rooms.Add(new List<RoomBase>());
            var yRoom = _rooms[y];
            for (int x = 0; x < _floorWidth; x++)
            {    
                string roomType = "base";
                for (int i = 0; i < importantRooms.Count(); i++) //Problem with the loop
                {
                    if(importantRooms[i][0] == x && importantRooms[i][1] == y)
                    {
                        var importantRoomType = importantRooms[i][2]; 
                        if(importantRoomType == 0)
                            roomType = "start";
                        else if(importantRoomType == 1)
                            roomType = "arrow";
                        else if(importantRoomType == 2)
                            roomType = "dragon";
                        else if(importantRoomType == 3)
                            roomType = "trap";
                        else if(importantRoomType == 4)
                            roomType = "slide";
                        break;
                    }
                }
                if(roomType == "start")
                {
                    var room = new StartingRoom();
                    yRoom.Add(room);
                    _executableRooms.Add(room);
                    _playerRoom = room;
                }
                else if(roomType == "arrow")
                {
                    var room = new ArrowRoom();
                    yRoom.Add(room);
                }
                else if(roomType == "dragon")
                {
                    var room = new DragonRoom();
                    yRoom.Add(room);
                    _executableRooms.Add(room);
                }
                else if(roomType == "trap")
                {
                    var room = new TrapRoom();
                    yRoom.Add(room);
                    _executableRooms.Add(room);
                }
                else if(roomType == "slide")
                {
                    var room = new SlideRoom();
                    yRoom.Add(room);
                }
                else
                    yRoom.Add(new RoomBase());
            }
        }

        executeRooms();
    }
    private void GenerateImportantRoomLocation(List<List<int>> GeneratedRooms, int type)
    {
        
        var roomLocation = new List<int>();
        bool isInvalid = true;
        while(isInvalid)
        {
            isInvalid = false;
            
            roomLocation.Add(_choice.Next(0, _floorWidth));
            roomLocation.Add(_choice.Next(0, _floorLength));
            roomLocation.Add(type);

            foreach(var room in GeneratedRooms)
            {
                if(room.GetRange(0, 2).SequenceEqual(roomLocation.GetRange(0, 2)))
                {
                    isInvalid = true;
                    roomLocation.Clear();
                    break;
                }
            }
        }
        GeneratedRooms.Add(roomLocation);
    }




    //Set up execution

    private void executeRooms()
    {
        var nearbyRooms = new List<RoomBase>();
        int index = 0;
        for (int y = 0; y < _floorLength; y++)
        {
            for (int x = 0; x < _floorWidth; x++)
            {
                index = ((y + _floorLength) -1) % _floorLength;
                nearbyRooms.Add(_rooms[index][x]); //North

                index = (x + 1) % _floorWidth;
                nearbyRooms.Add(_rooms[y][index]); //East

                index = (y + 1) % _floorLength;
                nearbyRooms.Add(_rooms[index][x]); //South

                index = ((x + _floorWidth) - 1) % _floorWidth;
                nearbyRooms.Add(_rooms[y][index]); //West

                _rooms[y][x].SetNearbyRooms(nearbyRooms);
                nearbyRooms.Clear();
            }
        }
        foreach(var room in _executableRooms)
        {
            room.StartingExecution();   
        }
    }

    public void displayRooms(bool revealAll = false)
    {
        Console.Clear();
        Console.WriteLine();
        foreach(var yRoom in _rooms)
        {
            foreach(var room in yRoom)
            {
                room.Display(revealAll);
            }
            Console.WriteLine();   
        }
        // Console.WriteLine(_playerRoom.GetType());
    }

    public string MovePlayer(int direction)
    {
        if(direction == 4)
        {
            return userShotGuess();
        }
        _playerRoom = _playerRoom.PlayerMoveOut(direction);
        return _playerRoom.ReturnRoomType();
    }

    public RoomBase GetRoom(int yIndex, int xIndex)
    {
        return _rooms[yIndex % _floorLength][xIndex % _floorWidth];
    }

    private string userShotGuess()
    {
        Console.WriteLine("Recalling all of your archery training from your past teacher, you draw your bow.\n Consentrate on where the dragon is...");
        int userRowGuess = GetUserInputInt("What row is the dragon in? ");
        int userColumnGuess = GetUserInputInt("What column is the dragon in? ");

        bool userGuessConferm = GetUserInputBoolYN($"Is the dragon in row {userRowGuess}, column {userColumnGuess}? ");

        if(userGuessConferm)
        {
            Console.Clear();
            Console.WriteLine($"With all the might you could muster you nock the enchanted arrow and pull back.\n Then to the arrow you wisper, \"Fly to room {userRowGuess}, {userColumnGuess} and slay the beast there,\" and release the arrow.");
            Console.Clear();
            for(int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            if(_rooms[userRowGuess -1][userColumnGuess -1].Equals(typeof(DragonRoom)))
                return "hit";
            else
                return "missed";
        }
        else
            return "safe";
    }

    private bool GetUserInputBoolYN(string message)
    {
        while(true)
        {
            Console.Write(message);
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "yes")
                return true;
            else if(userInput == "no")
                return false;
            else
                Console.WriteLine("Please enter \"yes\" or \"no\"");
        }
    }
    private int GetUserInputInt(string message)
    {
        while(true)
            try
            {
                Console.Write(message);
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number.");
            }
            
    }
}