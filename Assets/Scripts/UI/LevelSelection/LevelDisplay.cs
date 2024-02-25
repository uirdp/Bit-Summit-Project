using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public GameObject[] Levels;
    private int index = 0;

    public void DisplayNextLevel()
    {
        Levels[index++].SetActive(false);
        Levels[index].SetActive(true);
    }
}
