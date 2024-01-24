using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float TimeToCompleteQuestion =   30f;
    [SerializeField] float TimeToShowCorrectAnswer = 10f;
    public bool IsAnswering;
    public bool loadNextQuestion;
    public float fillFraction;
    float timeValue;
    public void Update()
    {
        UpdateTime();
        
    }
    public void CancelTime()
    {
        timeValue=0;
    }
    public void UpdateTime()
    {
        timeValue -= Time.deltaTime;
        if(IsAnswering)
        {
            if(timeValue>0)
            {   
                fillFraction = timeValue / TimeToCompleteQuestion;
            }
            else
            {
                IsAnswering=false;
                timeValue=TimeToShowCorrectAnswer;
            }
        }
        else 
        {
            if(timeValue>0)
            {
                fillFraction = timeValue / TimeToShowCorrectAnswer;
            }
            else
            {
                IsAnswering=true;
                timeValue=TimeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

    }
}
