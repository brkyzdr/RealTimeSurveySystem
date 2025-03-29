using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SurveyManager : MonoBehaviour
{
    public static SurveyManager Instance;

    public GameObject surveyUIPrefab;

    private GameObject currentSurveyUI;

    // Stores the answers for all survey questions
    private Dictionary<string, string> answers = new Dictionary<string, string>();

    // Base URL of the Google Form (should not include any entry parameters)
    [TextArea]
    public string baseFormURL = "https://docs.google.com/forms/d/e/.../viewform?usp=pp_url";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowSurvey(string question, string entryID, SurveyQuestionType type, bool isFinalTrigger, System.Action onComplete = null)
    {
        if (currentSurveyUI != null) return;

        currentSurveyUI = Instantiate(surveyUIPrefab, transform);
        var ui = currentSurveyUI.GetComponent<SurveyUI>();

        ui.Setup(question, entryID, type, (string answer) =>
        {
            answers[entryID] = answer;
            Destroy(currentSurveyUI);
            currentSurveyUI = null;

            if (isFinalTrigger)
                SendAllAnswers();

            onComplete?.Invoke();
        });
    }

    private void SendAllAnswers()
    {
        string finalURL = baseFormURL;

        foreach (var entry in answers)
        {
            finalURL += $"&{entry.Key}={UnityWebRequest.EscapeURL(entry.Value)}";
        }

        Debug.Log("RTSS: Submitting all answers → " + finalURL);
        Application.OpenURL(finalURL);
    }
}
