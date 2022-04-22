using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float stop;
    private float currentTime = 0;
    private float startingTime = 60;
    [SerializeField] Text countDownText;
    public GameObject timeOverUI;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        stop = currentTime;
        countDownText.text = currentTime.ToString("0");
        if(stop <= 0)
        {
            TimeOver();
        }
    }

    void TimeOver()
    {
        timeOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}