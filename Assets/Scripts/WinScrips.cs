using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScrips : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    ScoreKeeper score;
    public void Awake()
    {
        score = FindAnyObjectByType<ScoreKeeper>();
    }
    public void winTitle()
    {
        finalScore.text = "Congratulations! \n" + "You win with " + score.CalculatorScore() + "%";
    }

}
