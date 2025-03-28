using UnityEngine;

public class SurveyManager : MonoBehaviour
{
    public static SurveyManager Instance;
    public GameObject surveyUIPrefab;

    private GameObject currentSurveyUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowSurvey(string question, string formURL, SurveyQuestionType type, System.Action onComplete = null)
    {
        if (currentSurveyUI != null) return;

        currentSurveyUI = Instantiate(surveyUIPrefab, transform);
        var ui = currentSurveyUI.GetComponent<SurveyUI>();
        ui.Setup(question, formURL, type, () =>
        {
            Destroy(currentSurveyUI);
            currentSurveyUI = null;
            onComplete?.Invoke();
        });
    }

}
