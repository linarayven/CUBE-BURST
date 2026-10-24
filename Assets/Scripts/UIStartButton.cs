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
        if (exitButton != null)    exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        Debug.Log("Start pressed");
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Debug.Log("Exit pressed");
        Application.Quit();
    }
}