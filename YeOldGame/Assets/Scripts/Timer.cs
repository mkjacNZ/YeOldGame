using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float startTime = 0f;
    public static float currentTime = 0f;
    float endTime = 0f;
    float winningTime = 32f;
    bool buttonShown = false;
    public GameObject button;

    public static bool gameOver = false;

    public TextMeshProUGUI timeText;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        startTime = Time.time;
        endTime = 0f;
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
            if (!buttonShown)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Instantiate(button, GameObject.Find("Canvas").transform);
                buttonShown = true;
            }

            gameOver = true;
            endTime = currentTime;
            audioSource.Play();
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
