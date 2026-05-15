using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playGame;
    [SerializeField] Button quitGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playGame.onClick.AddListener(LoadGameScene);
        quitGame.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}