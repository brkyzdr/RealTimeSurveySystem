using UnityEngine;
using UnityEngine.UI;

public class SurveyManager : MonoBehaviour
{
    public GameObject surveyUIPrefab;
    private GameObject currentSurveyUI;

    public void ShowSurvey(string question, string googleFormURL)
    {
        if (currentSurveyUI != null) return;

        currentSurveyUI = Instantiate(surveyUIPrefab, transform);
        var ui = currentSurveyUI.GetComponent<SurveyUI>();
        ui.Setup(question, googleFormURL);
    }

    public void CloseSurvey()
    {
        if (currentSurveyUI != null)
            Destroy(currentSurveyUI);
    }
}
