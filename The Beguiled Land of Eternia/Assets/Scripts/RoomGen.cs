using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    public GameObject RoomVisualizer;
    public GameObject UpHallwayVisualizer;
    public GameObject RightHallwayVisualizer;
    void Start()
    {
        RoomGenerator DearGod = new RoomGenerator(10, 12);

        foreach (KeyValuePair<int, Dictionary<int, Room>> Entry in DearGod.Rooms)
        {
            foreach (KeyValuePair<int, Room> Entry2 in Entry.Value)
            {
                Room CurrentRoom = Entry2.Value;
                GameObject RoomVisual = Instantiate(RoomVisualizer, new Vector3(CurrentRoom.x, CurrentRoom.y, 0), new Quaternion(0, 0, 0, 0));

                if (CurrentRoom.Type == "StartingRoom")
                {
                    RoomVisual.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1);
                }
                if (CurrentRoom.Type == "BossRoom")
                {
                    RoomVisual.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                }
                if (CurrentRoom.Type == "TreasureRoom")
                {
                    RoomVisual.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
                }

                if (CurrentRoom.ConnectingDirections[Directions.North])
                {
                    Instantiate(UpHallwayVisualizer, new Vector3(CurrentRoom.x, CurrentRoom.y + 0.5f, 0), new Quaternion(0, 0, 0, 0));
                }
                if (CurrentRoom.ConnectingDirections[Directions.South])
                {
                    Instantiate(UpHallwayVisualizer, new Vector3(CurrentRoom.x, CurrentRoom.y - 0.5f, 0), new Quaternion(0, 0, 0, 0));
                }
                if (CurrentRoom.ConnectingDirections[Directions.West])
                {
                    Instantiate(RightHallwayVisualizer, new Vector3(CurrentRoom.x - 0.5f, CurrentRoom.y, 0), new Quaternion(0, 0, 0, 0));
                }
                if (CurrentRoom.ConnectingDirections[Directions.East])
                {
                    Instantiate(RightHallwayVisualizer, new Vector3(CurrentRoom.x + 0.5f, CurrentRoom.y, 0), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
public enum Directions
{
    North,
    South,
    West,
    East
}
public class RoomGenerator
{
    public int RoomCount; //current rooms count
    private int MaxRoomCount; //maximum allowed rooms

    private Room CurrentRoom;

    public Dictionary<int, Dictionary<int, Room>> Rooms = new Dictionary<int, Dictionary<int, Room>>(); //2D dictionary :fearful:
    public List<Room> UnsortedRooms = new List<Room>();
    public RoomGenerator(int RoomMin, int RoomMax) //constructor, also roommin and roommax dont count towards boss rooms and treasure rooms
    {
        RoomCount = 0;
        MaxRoomCount = Random.Range(RoomMin, RoomMax);

        CurrentRoom = new Room(0, 0, this, "StartingRoom");

        while (RoomCount < MaxRoomCount)
        {
            GenerateRoom("Room");
        }

        bool BossRoomGenerated = false;
        while (!BossRoomGenerated)
        {
            GenerationResult BossRoomResult = GenerateRoom("BossRoom");
            if (BossRoomResult.Success)
            {
                BossRoomGenerated = true;
            }
        }

        bool GenerateTreasureRooms = true;
        float GenerateRoll = Random.Range(2.5f, 4);
        while (GenerateTreasureRooms)
        {
            if (GenerateRoll >= 3)
            {
                bool RoomGenerated = false;
                while (!RoomGenerated)
                {
                    GenerationResult TreasureRoomResult = GenerateRoom("TreasureRoom");
                    if (TreasureRoomResult.Success)
                    {
                        RoomGenerated = true;
                    }
                }
                GenerateRoll = Random.Range(0, 4);
            }
            else
            {
                GenerateTreasureRooms = false;
            }
        }

        Debug.Log("Rooms all generated with a count of " + RoomCount);
    }
    private Vector2 AdjustCoordinatesByDirection(Vector2 Coordinates, Directions Direction)
    {
        switch (Direction)
        {
            case Directions.North:
                return Coordinates + new Vector2(0, 1);
            case Directions.South:
                return Coordinates + new Vector2(0, -1);
            case Directions.West:
                return Coordinates + new Vector2(-1, 0);
            case Directions.East:
                return Coordinates + new Vector2(1, 0);
            default:
                return Coordinates;
        }
    }
    private Directions FlipDirection(Directions Direction)
    {
        switch (Direction)
        {
            case Directions.North:
                return Directions.South;
            case Directions.South:
                return Directions.North;
            case Directions.West:
                return Directions.East;
            case Directions.East:
                return Directions.West;
            default:
                return Directions.South;
        }
    }
    private Room GetRandomRoom()
    {
        int Index = Random.Range(0, UnsortedRooms.Count);
        Room RandomRoom = UnsortedRooms[Index];
        if (RandomRoom.IsNode)
        {
            return RandomRoom;
        }
        else
        {
            return GetRandomRoom();
        }
    }
    private GenerationResult GenerateRoom(string Type)
    {
        if (!CurrentRoom.IsNode)
        {
            CurrentRoom = GetRandomRoom();
            return new GenerationResult(false);
        }

        List<Directions> AvailableDirections = new List<Directions>();
        foreach (KeyValuePair<Directions, bool> Entry in CurrentRoom.ConnectingDirections)
        {
            if (!Entry.Value)
            {
                AvailableDirections.Add(Entry.Key);
            }
        }

        if (AvailableDirections.Count == 0)
        {
            CurrentRoom = GetRandomRoom();
            return new GenerationResult(false);
        }

        int Index = Random.Range(0, AvailableDirections.Count);
        Directions Direction = AvailableDirections[Index];
        Vector2 RoomCheckCoordinates = AdjustCoordinatesByDirection(new Vector2(CurrentRoom.x, CurrentRoom.y), Direction);

        if (Rooms.ContainsKey((int)RoomCheckCoordinates.x) && Rooms[(int)RoomCheckCoordinates.x].ContainsKey((int)RoomCheckCoordinates.y))
        {
            if (Random.Range(0, 6) > 1)
            {
                CurrentRoom.ConnectingDirections[Direction] = true;
                Rooms[(int)RoomCheckCoordinates.x][(int)RoomCheckCoordinates.y].ConnectingDirections[FlipDirection(Direction)] = true;
            }
            CurrentRoom = GetRandomRoom();
            return new GenerationResult(false);
        }

        if (Type == "BossRoom" || Type == "TreasureRoom")
        {
            if (Mathf.Abs((int)RoomCheckCoordinates.x) <= 1 && Mathf.Abs((int)RoomCheckCoordinates.y) <= 1)
            {
                CurrentRoom = GetRandomRoom();
                return new GenerationResult(false);
            }
        }

        CurrentRoom.ConnectingDirections[Direction] = true;
        Room GeneratedRoom = new Room((int)RoomCheckCoordinates.x, (int)RoomCheckCoordinates.y, this, Type);
        GeneratedRoom.ConnectingDirections[FlipDirection(Direction)] = true;
        int WhatNext = Random.Range(0, 2);
        if (WhatNext == 1)
        {
            CurrentRoom = GeneratedRoom;
        }
        else if (WhatNext == 2)
        {
            CurrentRoom = GetRandomRoom();
        }
        return new GenerationResult(true, GeneratedRoom);
    }
}
public class Room
{
    public int x;
    public int y;
    public string Type;
    public bool IsNode;
    public Dictionary<Directions, bool> ConnectingDirections = new Dictionary<Directions, bool>();
    public Room(int room_x, int room_y, RoomGenerator Parent, string AssignedType)
    {
        x = room_x;
        y = room_y;

        Type = AssignedType;

        if (Type == "Room" || Type == "StartingRoom")
        {
            IsNode = true;
        }
        else
        {
            IsNode = false;
        }

        ConnectingDirections[Directions.North] = false;
        ConnectingDirections[Directions.South] = false;
        ConnectingDirections[Directions.West] = false;
        ConnectingDirections[Directions.East] = false;

        if (!Parent.Rooms.ContainsKey(x))
        {
            Parent.Rooms[x] = new Dictionary<int, Room>();
        }

        Parent.Rooms[x][y] = this;
        Parent.UnsortedRooms.Add(this);

        Parent.RoomCount += 1;
    }
}
public class GenerationResult //used to store return values from GenerateRoom functions
{
    public bool Success;
    public Room Room;
    public GenerationResult(bool WasSuccessful)
    {
        Success = WasSuccessful;
    }
    public GenerationResult(bool WasSuccessful, Room GeneratedRoom)
    {
        Success = WasSuccessful;
        Room = GeneratedRoom;
    }
}