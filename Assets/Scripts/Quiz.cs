using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using System.Threading;
using System.Timers;
using Unity.Mathematics;
using Random = UnityEngine.Random;



public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI QuestionsText;
    [SerializeField] List<Questions> questions = new List<Questions>();   
    Questions currentQuestions;

    [Header("Answer")]
    [SerializeField] GameObject[] buttonAnswer;
    int correctAnswerIndex;
    bool hasAnswerEarly=true;

    [Header("Color button")]
    [SerializeField] Sprite choseCorrectAnswerIndex;
    [SerializeField] Sprite defaultCorrectAnswerIndex;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreText;
    ScoreKeeper score;

    [Header("Sllider")]
    [SerializeField] Slider sliderComplete;
    public bool isComplete;
    public void Awake()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        
        sliderComplete.maxValue = questions.Count;
        sliderComplete.value=0;
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if(sliderComplete.value==sliderComplete.maxValue)
            {
                isComplete = true;
            }
            hasAnswerEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnswerEarly && !timer.IsAnswering)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnCorrectAnswerIndex(int index)
    {       
        hasAnswerEarly = true;
        DisplayAnswer(index); 
        SetButtonState(false);
        timer.CancelTime();
        ScoreText.text = "Score " + score.CalculatorScore() + "%";

        
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if(index == currentQuestions.GetCorrectAnswer())
        {
            QuestionsText.text = "Correct!";
            buttonImage = buttonAnswer[index].GetComponent<Image>();
            buttonImage.sprite = choseCorrectAnswerIndex;
            score.IncrementCorrectAnswer();
        }
        else
        {
            correctAnswerIndex = currentQuestions.GetCorrectAnswer();
            string correctAnswer = currentQuestions.GetAnswers(correctAnswerIndex);
            QuestionsText.text = "Wrong! The answer is \n" + correctAnswer;
            buttonImage = buttonAnswer[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = choseCorrectAnswerIndex;
        }
        
    }
    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestions();
            DisplayQuestion();
            sliderComplete.value++;
            score.IncrementQuestionSeen();
        }
    }
    void GetRandomQuestions()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestions = questions[index];
        if(questions.Contains(currentQuestions))
        {
            questions.Remove(currentQuestions);
        }
    }
    void DisplayQuestion()
    {
        QuestionsText.text = currentQuestions.GetQuestion();

        for (int i=0; i<buttonAnswer.Length;i++)
        {
            TextMeshProUGUI AnswerText = buttonAnswer[i].GetComponentInChildren<TextMeshProUGUI>();
            AnswerText.text = currentQuestions.GetAnswers(i);
        }
    }
    void SetButtonState(bool state)
    {
        for(int i =  0; i< buttonAnswer.Length; i++ )
        {
            Button button = buttonAnswer[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetDefaultButtonSprite()
    {
        for (int i=0; i<buttonAnswer.Length; i++)
        {   
            Image buttonImage = buttonAnswer[i].GetComponent<Image>();
            buttonImage.sprite = defaultCorrectAnswerIndex;

        }
    }
}
