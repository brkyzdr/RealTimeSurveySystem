using UnityEngine;

public class SurveyTriggerTimer : MonoBehaviour
{
    [Header("Survey Question Data")]
    public SurveyQuestionData questionData;

    [Header("Trigger Settings")]
    [Tooltip("Trigger will activate after this many minutes.")]
    public float delayInMinutes = 1f;

    public bool pauseGameOnSurvey = true;

    private bool triggered = false;

    void Start()
    {
        Invoke(nameof(TriggerSurvey), delayInMinutes * 60f);
    }

    private void TriggerSurvey()
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
