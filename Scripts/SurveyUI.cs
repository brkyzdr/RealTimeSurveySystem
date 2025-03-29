using UnityEngine;
using UnityEngine.UI;

public class SurveyUI : MonoBehaviour
{
    [Header("General")]
    public Text questionText;

    [Header("Yes / No Panel")]
    public GameObject yesNoPanel;
    public Button answerButton1; // Yes
    public Button answerButton2; // No

    [Header("Paragraph Panel")]
    public GameObject paragraphPanel;
    public InputField paragraphInput;
    public Button submitParagraph;

    [Header("Scale Panel (1–10)")]
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

        // Disable all panels
        yesNoPanel.SetActive(false);
        paragraphPanel.SetActive(false);
        scalePanel.SetActive(false);

        // Activate the correct panel based on the question type
        switch (type)
        {
            case SurveyQuestionType.YesNo:
                yesNoPanel.SetActive(true);
                answerButton1.onClick.AddListener(() => SubmitAnswer("Yes"));
                answerButton2.onClick.AddListener(() => SubmitAnswer("No"));
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
