using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    WinScrips winScrips;
    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        winScrips = FindObjectOfType<WinScrips>();

        quiz.gameObject.SetActive(true);
        winScrips.gameObject.SetActive(false);
    }

    void Update()
    {
       if(quiz.isComplete ==true)
       {
        quiz.gameObject.SetActive(false);
        winScrips.gameObject.SetActive(true);
        winScrips.winTitle();
        
       }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
