using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void LoadDemoLevel()
    {
        Debug.Log("calling Demo");
        SceneManager.LoadScene("Demo Level");
    }
    public void LoadGardenLevel()
    {
        Debug.Log("calling Garden");
        SceneManager.LoadScene("Garden");
    }
}
