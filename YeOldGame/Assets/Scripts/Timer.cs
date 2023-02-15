using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float startTime = 0f;
    float currentTime = 0f;
    float endTime = 0f;
    float winningTime = 20f;

    bool gameOver = false;

    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (!gameOver)
        {
            timeText.text = string.Format("Time: {0:#.00} seconds", currentTime);
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
