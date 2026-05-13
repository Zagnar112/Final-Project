using UnityEngine;
using TMPro;

public class Timert : MonoBehaviour
{

    public float timer;
    public TMP_Text timerText;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timerText.text = Mathf.FloorToInt(timer).ToString();
    }
}
