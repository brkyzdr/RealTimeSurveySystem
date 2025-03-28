using UnityEngine;
using UnityEngine.UI;

public class SurveyUI : MonoBehaviour
{
    [Header("Genel")]
    public Text questionText;

    [Header("Evet / Hayır Paneli")]
    public GameObject yesNoPanel;
    public Button answerButton1; // Evet
    public Button answerButton2; // Hayır

    [Header("Paragraf Paneli")]
    public GameObject paragraphPanel;
    public InputField paragraphInput;
    public Button submitParagraph;

    [Header("Skala Paneli (1–10)")]
    public GameObject scalePanel;
    public Slider scaleSlider;
    public Text scaleValueText;
    public Button submitScale;

    private string entryID;
    private System.Action<string> onAnswerSubmitted;

    public void Setup(string question, string entry, SurveyQuestionType type, System.Action<string> onComplete)
    {
        questionText.text = question;
        entryID = entry;
        onAnswerSubmitted = onComplete;

        // Tüm panelleri devre dışı bırak
        yesNoPanel.SetActive(false);
        paragraphPanel.SetActive(false);
        scalePanel.SetActive(false);

        // Soru tipine göre doğru paneli göster
        switch (type)
        {
            case SurveyQuestionType.YesNo:
                yesNoPanel.SetActive(true);
                answerButton1.onClick.AddListener(() => SubmitAnswer("Evet"));
                answerButton2.onClick.AddListener(() => SubmitAnswer("Hayır"));
                break;

            case SurveyQuestionType.Paragraph:
                paragraphPanel.SetActive(true);
                submitParagraph.onClick.AddListener(() =>
                {
                    string input = paragraphInput.text.Trim();
                    if (!string.IsNullOrEmpty(input))
                        SubmitAnswer(input);
                });
                break;

            case SurveyQuestionType.Scale1to10:
                scalePanel.SetActive(true);
                scaleSlider.onValueChanged.AddListener(val =>
                {
                    scaleValueText.text = val.ToString("0");
                });
                submitScale.onClick.AddListener(() =>
                {
                    SubmitAnswer(scaleSlider.value.ToString("0"));
                });
                break;
        }
    }

    void SubmitAnswer(string answer)
    {
        onAnswerSubmitted?.Invoke(answer);
    }
}
