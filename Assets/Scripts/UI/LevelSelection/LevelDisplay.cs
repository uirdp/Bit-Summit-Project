using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDisplay : MonoBehaviour
{
    public Level[] Levels;
    private int index = 0;

    public int Index => index;
    public void DisplayNextLevel()
    {
        Levels[index++].gameObject.SetActive(false);

        CheckIndex();

        Levels[index].gameObject.SetActive(true);
    }

    public void DisplayPreviousLevel()
    {
        Debug.Log("called");
        Levels[index--].gameObject.SetActive(false);

        CheckIndex();

        Levels[index].gameObject.SetActive(true);
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

    public void LoadLevel()
    {
        string levelName = Levels[index].levelName;
        SceneManager.LoadScene(levelName);
    }

}
