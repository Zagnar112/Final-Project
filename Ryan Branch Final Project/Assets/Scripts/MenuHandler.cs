using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] Button playGame;
    [SerializeField] Button optionButton;
    [SerializeField] Button quitGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playGame.onClick.AddListener(LoadGameScene);
        quitGame.onClick.AddListener(QuitGame);
        optionButton.onClick.AddListener(Options);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Options()
    {
        SceneManager.LoadScene("Options Scene");
    }
}