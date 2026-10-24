using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBackButton : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        if (backButton != null) backButton.onClick.AddListener(Back);
    }

    public void Back() { SceneManager.LoadScene("MainMenuScene"); }
}