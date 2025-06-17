using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text feedbackText;

    [Header("Tester Accounts")]
    public List<TesterAccount> testerAccounts = new List<TesterAccount>();

    void Start()
    {
        feedbackText.text = "";
    }

    public void TryLogin()
    {
        string user = usernameInput.text.Trim();
        string pass = passwordInput.text;

        foreach (TesterAccount account in testerAccounts)
        {
            if (account.username == user && account.password == pass)
            {
                feedbackText.text = "Login successful!";
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
        }

        feedbackText.text = "Invalid username or password.";
    }
}

[System.Serializable]
public class TesterAccount
{
    public string username;
    public string password;
}
