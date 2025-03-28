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

    public void ShowSurvey(string question, string googleFormURL, System.Action onComplete = null)
    {
        if (currentSurveyUI != null) return;

        currentSurveyUI = Instantiate(surveyUIPrefab, transform);
        var ui = currentSurveyUI.GetComponent<SurveyUI>();
        ui.Setup(question, googleFormURL, () =>
        {
            Destroy(currentSurveyUI);
            currentSurveyUI = null;

            onComplete?.Invoke(); // Trigger'dan gelen callback çalıştırılır
        });
    }
}
