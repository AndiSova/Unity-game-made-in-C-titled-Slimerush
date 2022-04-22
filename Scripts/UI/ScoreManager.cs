using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int score;
    public int maxScore;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        text.text = score.ToString() + "/" + maxScore.ToString();
    }

    public void ChangeScore(int CoinValue)
    {
        score += CoinValue;
        text.text = score.ToString() + "/" + maxScore.ToString();
    }
}