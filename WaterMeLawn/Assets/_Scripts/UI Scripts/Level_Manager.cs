using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public string LevelName;

    public void RestartLevel()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(LevelName);
    }

}
