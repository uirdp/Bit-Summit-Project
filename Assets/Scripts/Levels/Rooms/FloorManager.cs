using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorManager : MonoBehaviour
{
    public ColorMatrixShifter matrixShifter;
    public Key[] keys;

    public int numOfAllKeys;
    public int numOfUnlockedKeys;

    public UnityEvent OnKeyCollectedEvent;
    public UnityEvent OnAllKeysCollectedEvent;

    public void OnKeyCollected()
    {
        numOfUnlockedKeys++;
        if (numOfUnlockedKeys >= numOfAllKeys) OnAllKeysCollectedEvent.Invoke();
        else OnKeyCollectedEvent.Invoke();
    }
}
