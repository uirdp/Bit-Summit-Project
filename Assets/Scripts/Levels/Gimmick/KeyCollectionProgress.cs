using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectionProgress : MonoBehaviour
{
    [SerializeField] 
    private int _keyAmount = 2;

    private int _progress = 0;

    private void Start()
    {
        Debug.Assert(_keyAmount >= 0, "key amount less than zero");
    }

    public void UpdateProgress()
    {
        _progress += 1;
        if (_progress >= _keyAmount)
        {
            Debug.Log("door opened");
        }
    }
}
