using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/RoomSet",
    fileName = "Create new room set")]
public class RoomSet : ScriptableObject
{
    [SerializeField] private List<GameObject> rooms;
    [SerializeField] private GameObject endRoom;

    private GameObject GetEndRoomPrefab()
    {
        if (endRoom == null)
        {
            Debug.LogError("End room prefab not set");
            return rooms[0];
        }
        return endRoom;
    }


    private GameObject GetNextRoomPrefab(bool finalRoom=false)
    {
        if (finalRoom)
        {
            return GetEndRoomPrefab();
        }
        return rooms[UnityEngine.Random.Range(0, rooms.Count)];
    }

    public RoomManager SpawnRoom(RoomManager oldRoom, bool finalRoom=false)
    {
        GameObject roomPrefab = GetNextRoomPrefab(finalRoom);
        RoomManager r = Instantiate(
                roomPrefab,
                oldRoom.GetEndPoint(),
                Quaternion.identity
            ).GetComponent<RoomManager>();
        r.AlignToPreviousRoom(oldRoom);
        return r;
    }
}


[Serializable]
public enum RoomType
{
    TimedSurvival = 0, // Survive for X seconds
    ItemCollection = 1 // Collect X items
}


[CreateAssetMenu(fileName = "Create new room", menuName = "ScriptableObjects/Room")]
public class ScriptableRoom : ScriptableObject
{
    [SerializeField] private RoomType Type;
}