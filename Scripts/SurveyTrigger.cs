using UnityEngine;
public class SurveyTrigger : MonoBehaviour
{
    [Header("Anket Sorusu")]
    [Tooltip("Bu tetikleyici çalıştığında gösterilecek soru.")]
    [TextArea(2, 4)]
    public string question = "Bu kısmı eğlenceli buldunuz mu?";

    [Tooltip("Bu sorunun tipini seçin.")]
    public SurveyQuestionType questionType = SurveyQuestionType.YesNo;

    [Header("Google Form Bilgileri")]
    [Tooltip("Google Form bağlantınızın başı. 'entry.xxxx=' kısmı hariç.")]
    [TextArea(1, 3)]
    public string baseFormURL = "https://docs.google.com/forms/d/e/.../viewform?usp=pp_url";

    [Tooltip("Bu sorunun bağlı olduğu entry ID. Örn: entry.1234567890")]
    public string entryID = "entry.1234567890";

    [Header("Ayarlar")]
    public bool pauseGameOnSurvey = true;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        string fullURL = $"{baseFormURL}&{entryID}=";

        if (pauseGameOnSurvey)
            Time.timeScale = 0;

        SurveyManager.Instance.ShowSurvey(question, fullURL, questionType, ResumeGameAfterSurvey);
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

