using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
  int correctAnswer=0;
  int questionsSeen=0;
  public int GetCorrectAnswer()
  {
    return correctAnswer;
  }
  public void IncrementCorrectAnswer()
  {
    correctAnswer++;
  }
  public int GetQuestionSeen()
  {
    return questionsSeen;
  }
  public void IncrementQuestionSeen()
  {
    questionsSeen++;
  }
  public int CalculatorScore()
  
  {
    return Mathf.RoundToInt( correctAnswer / (float)questionsSeen *100);
  }

}
