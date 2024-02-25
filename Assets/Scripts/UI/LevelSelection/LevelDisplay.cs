using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    public GameObject[] Levels;
    private int index = 0;

    public int Index => index;
    public void DisplayNextLevel()
    {
        Levels[index++].SetActive(false);

        CheckIndex();

        Levels[index].SetActive(true);
    }

    public void DisplayPreviousLevel()
    {
        Levels[index--].SetActive(false);

        CheckIndex();

        Levels[index].SetActive(true);
    }

    private void CheckIndex()
    {
        if (index >= Levels.Length)
        {
            index = 0;
        }

        if (index < 0)
        {
            index = Levels.Length - 1;
        }
    }

}
