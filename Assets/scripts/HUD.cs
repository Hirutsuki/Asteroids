using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    float elapsedTime = 0f;
    bool timerRunning;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning == true)
        {
            elapsedTime += Time.deltaTime;
            scoreText.text = ((int)elapsedTime).ToString();
        }
    }

    public void StopGameTimer()
    {
        timerRunning = false;
    }
}
