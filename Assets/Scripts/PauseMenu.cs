using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public TMP_Text buttonText;

    bool paused;

    void Start()
    {
        Time.timeScale = 1f;
        buttonText.text = "Pause";
        pauseButton.onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0f : 1f;
        buttonText.text = paused ? "Resume" : "Pause";
    }

    void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
