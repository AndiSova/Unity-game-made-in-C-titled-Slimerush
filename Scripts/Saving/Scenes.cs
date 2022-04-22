using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void Save()
    {
        PlayerPrefs.SetInt("SceneSaved", SceneManager.GetActiveScene().buildIndex);
    }

    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSaved"));
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
