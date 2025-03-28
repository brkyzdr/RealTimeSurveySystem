using UnityEngine;
using UnityEngine.UI;

public class SurveyUI : MonoBehaviour
{
    [Header("Genel UI")]
    public Text questionText;

    [Header("Evet/Hayır Tipi")]
    public GameObject yesNoPanel;
    public Button answerButton1;
    public Button answerButton2;

    [Header("Paragraf Tipi")]
    public GameObject paragraphPanel;
    public InputField paragraphInput;
    public Button submitParagraph;

    [Header("Skala Tipi")]
    public GameObject scalePanel;
    public Slider scaleSlider;
    public Text scaleValueText;
    public Button submitScale;

    private string googleFormURL;
    private System.Action onAnswerSubmitted;

    public void Setup(string question, string url, SurveyQuestionType type, System.Action onComplete)
    {
        questionText.text = question;
        googleFormURL = url;
        onAnswerSubmitted = onComplete;

        yesNoPanel.SetActive(false);
        paragraphPanel.SetActive(false);
        scalePanel.SetActive(false);

        switch (type)
        {
            case SurveyQuestionType.YesNo:
                yesNoPanel.SetActive(true);
                answerButton1.onClick.AddListener(() => SubmitAnswer("Evet"));
                answerButton2.onClick.AddListener(() => SubmitAnswer("Hayır"));
                break;

            case SurveyQuestionType.Paragraph:
                paragraphPanel.SetActive(true);
                submitParagraph.onClick.AddListener(() => SubmitAnswer(paragraphInput.text));
                break;

            case SurveyQuestionType.Scale1to10:
                scalePanel.SetActive(true);
                scaleSlider.onValueChanged.AddListener(val => scaleValueText.text = val.ToString("0"));
                submitScale.onClick.AddListener(() => SubmitAnswer(scaleSlider.value.ToString("0")));
                break;
        }
    }

    void SubmitAnswer(string answer)
    {
        Application.OpenURL(googleFormURL + answer);
        onAnswerSubmitted?.Invoke();
    }
}
