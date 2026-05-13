using UnityEngine;
using UnityEngine.SceneManagement;

public class HitObject : MonoBehaviour
{
    [Header("Scene To Load")]
    public string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if collided object has the "Obstacle" tag
        if (other.CompareTag("Obstacle"))
        {
            //SceneManager.LoadScene(endScreen);
        }
    }
}
