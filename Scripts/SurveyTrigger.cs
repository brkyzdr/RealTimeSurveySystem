using UnityEngine;
public class SurveyTrigger : MonoBehaviour
{
    [Header("Anket Sorusu")]
    [TextArea(2, 4)]
    public string question = "Bu kısmı eğlenceli buldunuz mu?";

    public SurveyQuestionType questionType = SurveyQuestionType.YesNo;

    [Header("Google Form Entry ID")]
    [Tooltip("Bu sorunun Google Form'daki entry ID'si")]
    public string entryID = "entry.1234567890";

    [Header("Ayarlar")]
    public bool isFinalTrigger = false;
    public bool pauseGameOnSurvey = true;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        if (pauseGameOnSurvey)
            Time.timeScale = 0;

        SurveyManager.Instance.ShowSurvey(
            question,
            entryID,
            questionType,
            isFinalTrigger,
            ResumeGameAfterSurvey
        );
    }

    private void ResumeGameAfterSurvey()
    {
        if (pauseGameOnSurvey)
            Time.timeScale = 1;
    }
}


public enum SurveyQuestionType
{
    YesNo,
    Paragraph,
    Scale1to10
}

