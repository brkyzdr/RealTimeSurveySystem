using UnityEngine;

public class SurveyTriggerArea : MonoBehaviour
{
    [Header("Survey Question Data")]
    public SurveyQuestionData questionData;

    [Header("Settings")]
    public bool pauseGameOnSurvey = true;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        TriggerSurvey();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        TriggerSurvey();
    }

    private void TriggerSurvey()
    {
        triggered = true;

        if (pauseGameOnSurvey)
            Time.timeScale = 0;

        SurveyManager.Instance.ShowSurvey(
            questionData.questionText,
            questionData.entryID,
            questionData.questionType,
            questionData.isFinal,
            ResumeGameAfterSurvey
        );
    }

    private void ResumeGameAfterSurvey()
    {
        if (pauseGameOnSurvey)
            Time.timeScale = 1;
    }
}
