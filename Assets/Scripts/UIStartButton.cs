using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartButton : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;

    void Start()
    {
        if (startButton != null)   startButton.onClick.AddListener(StartGame);
        if (optionsButton != null) optionsButton.onClick.AddListener(OpenOptions);
        if (exitButton != null)    exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()   { SceneManager.LoadScene("GameScene"); }
    public void OpenOptions() { SceneManager.LoadScene("OptionsMenu"); }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}