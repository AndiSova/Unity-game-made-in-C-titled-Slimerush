using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private int currentSceneIndex;

    public void Return()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Main Menu");
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
    }
}
