using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public static bool GameisPaused = true;
    public GameObject WinUI;
    private ScoreManager winScore;

    private void Awake()
    {
        winScore = GameObject.FindObjectOfType<ScoreManager>();
    }
    public void NextGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Return()
    {
        SceneManager.LoadScene("Main Menu");

    }
    void Pause()
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f;
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(winScore.score == winScore.maxScore)
        {
            Pause();
        }
    }
}