using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz", fileName = "New Questions")]
public class Questions : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string QuestionsQuiz = "Enter new quiz";
    [TextArea(1,3)]
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswer;
    public string GetQuestion()
    {
        return QuestionsQuiz;
    }
    public string GetAnswers(int index)
    {
        return answers[index];
    }
    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
}
