using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Michsky.UI.Heat;

public class LevelLoader : MonoBehaviour
{
    public ChapterManager chapterManager;

    public void LoadLevel()
    {
        chapterManager.chapters[chapterManager.currentChapterIndex].onPlay.Invoke();
    }
    public void LoadGardenLevel()
    {
        SceneManager.LoadScene("GardenScene");
    }

    public void LoadOasisLevel()
    {
        SceneManager.LoadScene("OasisScene");
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
