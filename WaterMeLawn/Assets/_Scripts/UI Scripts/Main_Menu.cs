using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] string level;

    // Update is called once per frame
    void Awake()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(level);
    }
}
