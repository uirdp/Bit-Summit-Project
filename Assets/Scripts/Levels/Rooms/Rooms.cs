using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public ColorMatrixShifter[] shifters;

    public void WakeUpShifter(int roomId)
    {
        shifters[roomId].StartShifting();
    }

    public void Start()
    {
        shifters[0].StartShifting();
    }
}
