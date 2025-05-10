using UnityEngine;

public class SurveyTriggerEvent : MonoBehaviour
{
    [Header("Survey Question Data")]
    public SurveyQuestionData questionData;

    [Header("Trigger Settings")]
    public bool pauseGameOnSurvey = true;

    private bool triggered = false;

    public void TriggerSurveyExternally()
    {
        if (triggered) return;
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
