using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameplayUI;
    [SerializeField] string CurrentLevel;

    // Update is called once per frame
    void Update()
    {
        CurrentLevel = SceneManager.GetActiveScene().name;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        GameplayUI.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        GameplayUI.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu Build");
    }
}
