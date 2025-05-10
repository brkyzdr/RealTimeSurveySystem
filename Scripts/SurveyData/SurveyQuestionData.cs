using UnityEngine;

[CreateAssetMenu(fileName = "NewSurveyQuestion", menuName = "RTSS/Survey Question", order = 0)]
public class SurveyQuestionData : ScriptableObject
{
    [TextArea(2, 4)]
    public string questionText;

    [Tooltip("Google Form'daki entry ID (örnek: entry.1234567890)")]
    public string entryID;

    public SurveyQuestionType questionType = SurveyQuestionType.YesNo;

    [Tooltip("Eğer bu soru son soruyu temsil ediyorsa, form gönderimi yapılır.")]
    public bool isFinal = false;
}
