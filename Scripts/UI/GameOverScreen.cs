using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static bool GameisPaused = true;
    public GameObject gameOverUI;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void Pause()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    void Update()
    {
        if (player.curHealth <= 0)
        {
            Pause();
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Return()
    {
        SceneManager.LoadScene("Main Menu");

    }
    
}