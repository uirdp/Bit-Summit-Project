using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public ColorMatrixShifter[] shifters;
    public int InitRoomAmout = 1;

    public void WakeUpShifter(int roomId)
    {
        shifters[roomId].StartShifting();
    }

    public void Start()
    {
        for(int i = 0; i < InitRoomAmout; i++)
        {
            if (i >= InitRoomAmout) break;
            shifters[i].StartShifting();
        }
    }
}
