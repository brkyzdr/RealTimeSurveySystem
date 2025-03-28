using UnityEngine;

public class SurveyTrigger : MonoBehaviour
{
    public string question = "Bu kısmı eğlenceli buldunuz mu?";
    public string googleFormURL = "https://docs.google.com/forms/d/e/your-form-id/viewform?usp=pp_url&entry.1234567890=";

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        triggered = true;

        FindObjectOfType<SurveyManager>().ShowSurvey(question, googleFormURL);
    }
}
