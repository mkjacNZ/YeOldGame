using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Timer : MonoBehaviour
{
    float startTime = 0f;
    public static float currentTime = 0f;
    float endTime = 0f;
    float winningTime = 20f;

    bool gameOver = false;

    public TextMeshProUGUI timeText;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.timeSinceLevelLoad;
        if (!gameOver)
        {
            if (currentTime < 1f)
            {
                timeText.text = string.Format("Time: 0{0:#.00} seconds", currentTime);
            }
            else
            {
                timeText.text = string.Format("Time: {0:#.00} seconds", currentTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !gameOver)
        {
            gameOver = true;
            endTime = currentTime;
            if (endTime <= winningTime)
            {
                timeText.text = string.Format("You won in {0:#.00} seconds!", endTime);
            }
            else
            {
                timeText.text = string.Format("You lost in {0:#.00} seconds!", endTime);
            }
        }
    }
}
