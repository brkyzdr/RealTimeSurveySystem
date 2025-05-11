using UnityEngine;

[CreateAssetMenu(fileName = "NewSurveyQuestion", menuName = "RTSS/Survey Question", order = 0)]
public class SurveyQuestionData : ScriptableObject
{
    [TextArea(2, 4)]
    public string questionText;

    [Tooltip("Entry ID in the Google Form (e.g., entry.1234567890)")]
    public string entryID;

    public SurveyQuestionType questionType = SurveyQuestionType.YesNo;

    [Tooltip("If this question is marked as final, the form will be submitted.")]
    public bool isFinal = false;
}
