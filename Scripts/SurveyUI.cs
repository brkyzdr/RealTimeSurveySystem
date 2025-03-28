using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SurveyUI : MonoBehaviour
{
    public Text questionText;
    public Button answerButton1;
    public Button answerButton2;

    private string googleFormURL;

    public void Setup(string question, string url)
    {
        questionText.text = question;
        googleFormURL = url;

        answerButton1.onClick.AddListener(() => SubmitAnswer("Evet"));
        answerButton2.onClick.AddListener(() => SubmitAnswer("Hayır"));
    }

    void SubmitAnswer(string answer)
    {
        Application.OpenURL(googleFormURL + "&entry.1234567890=" + answer);
        Destroy(gameObject);
    }
}
