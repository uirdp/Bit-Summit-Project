using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Heat;
using UnityEngine.Events;

//there should be another class to watch the progress
public class KeyProgressBar : MonoBehaviour
{
    public ProgressBar keyProgressBar;
    public int TotalAmountOfKeys;

    public UnityEvent LevelClearEvent;

    private float _percentage;

    private void Awake()
    {
        float p = 100.0f / TotalAmountOfKeys * 100;
        _percentage = Mathf.Ceil(p) * 0.01f;
    }

    public void Progress()
    {
        keyProgressBar.currentValue += _percentage;
        keyProgressBar.UpdateUI();

        if(keyProgressBar.currentValue >= 100)
        {
            keyProgressBar.currentValue = 100;
            LevelClearEvent.Invoke();
        }
    }


}
