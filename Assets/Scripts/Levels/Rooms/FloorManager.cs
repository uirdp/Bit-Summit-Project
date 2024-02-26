using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorManager : MonoBehaviour
{
    public ColorMatrixShifter matrixShifter;
    public Key[] keys;

    public UnityEvent OnKeyCollected;
    public UnityEvent OnAllKeysCollected;
}
