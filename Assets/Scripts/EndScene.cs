using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    [SerializeField] Button restart;
    [SerializeField] Button endGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        restart.onClick.AddListener(LoadMainMenu);
        endGame.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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