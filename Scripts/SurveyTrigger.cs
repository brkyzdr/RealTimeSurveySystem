using UnityEngine;

public class SurveyTrigger : MonoBehaviour
{
    [Header("Survey Question")]
    [TextArea(2, 4)]
    public string question = "Did you find this part enjoyable?";

    public SurveyQuestionType questionType = SurveyQuestionType.YesNo;

    [Header("Google Form Entry ID")]
    [Tooltip("The entry ID of this question in your Google Form")]
    public string entryID = "entry.1234567890";

    [Header("Settings")]
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
