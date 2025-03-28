using UnityEngine;

[CreateAssetMenu(fileName = "NewSurveyQuestion", menuName = "Survey/Question")]
public class SurveyQuestion : ScriptableObject
{
    public string QuestionText;
    public string[] Answers;
}
