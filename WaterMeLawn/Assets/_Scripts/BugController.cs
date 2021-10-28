using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BugController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private float timeRemaining;

    [SerializeField]
    private int bugsRemaining;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private GameObject progressBar;

    private bool lose = false;
    private bool win = false;
    private bool start = false;

    public int BugsRemaining { get => bugsRemaining; set => bugsRemaining = value; }
    public bool Lose { get => lose; }
    public bool Win { get => win;}
    public bool Start1 { get => start; set => start = value; }

    public GameObject[] canvasStates;

    private void Start()
    {
        Time.timeScale = 1;
        timer.SetActive(true);
        progressBar.SetActive(true);
        bugsRemaining = 8;
        progressSlider.value = bugsRemaining;
    }

    private void Update()
    {
        if (start == true)
        {
            BugsRemainingCheck();
        }
        LevelConditionCheck();
    }

    private void BugsRemainingCheck()
    {
        if (bugsRemaining > 0 && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString("00");
        }
        else if (bugsRemaining > 0 && timeRemaining <= 0)
        {
            timer.SetActive(false);
            progressBar.SetActive(false);
            //Lose State
            lose = true;
        }
        else if (bugsRemaining <= 0 && timeRemaining > 0)
        {
            timer.SetActive(false);
            progressBar.SetActive(false);
            //Enter win state
            win = true;
        }

        progressSlider.value = bugsRemaining;
    }

    private void LevelConditionCheck()
    {
        if (lose == true)
        {
            Time.timeScale = 0;
            canvasStates[0].SetActive(true);
        }

        if (win == true)
        {
            Time.timeScale = 0;
            canvasStates[1].SetActive(true);
        }
    }
}
