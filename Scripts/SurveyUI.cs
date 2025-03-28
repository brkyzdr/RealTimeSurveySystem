using UnityEngine;
using UnityEngine.UI;

public class SurveyUI : MonoBehaviour
{
    public Text questionText;
    public Button answerButton1;
    public Button answerButton2;

    private string googleFormURL;
    private System.Action onAnswerSubmitted;

    public void Setup(string question, string url, System.Action onComplete)
    {
        questionText.text = question;
        googleFormURL = url;
        onAnswerSubmitted = onComplete;

        answerButton1.onClick.AddListener(() => SubmitAnswer("Evet"));
        answerButton2.onClick.AddListener(() => SubmitAnswer("Hayır"));
    }

    void SubmitAnswer(string answer)
    {
        Application.OpenURL(googleFormURL + answer);

        onAnswerSubmitted?.Invoke(); // Cevap sonrası callback
    }
}
