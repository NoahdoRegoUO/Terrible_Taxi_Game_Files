using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int pedestrianCount;
    private double timeTaken;
    private static string timeDisplay;
    private AudioClip currentSong;
    public static bool gameEnded = false;
    public static GameObject gameOverScreen;
    public GameObject pauseMenu;
    public static bool paused;

    public static int GetPedestrianCount()
    {
        return pedestrianCount;
    }

    public static void SetPedestrianCount(int value)
    {
        pedestrianCount = value;
    }

    public static void MinusPedestrian()
    {
        pedestrianCount--;
    }

    public static string GetGameTime()
    {
        return timeDisplay;
    }

    public static void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            gameOverScreen.SetActive(true);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        pauseMenu.SetActive(true);
    }

    public void SetSong()
    {
        AudioSource audio = GetComponent<AudioSource>();
        currentSong = Settings.song;
        audio.clip = currentSong;
        audio.Play();
    }

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = Settings.song;
        audio.Play();
        pedestrianCount = 10;
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        GameOverScreen.setupFlag = true;
        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
        paused = false;
    }

    void Update()
    {
        // timer
        timeTaken = Time.timeSinceLevelLoad;
        TimeSpan interval = TimeSpan.FromSeconds(timeTaken);
        timeDisplay = string.Format("{0:D2}:{1:D2}.{2:D3}",
                interval.Minutes,
                interval.Seconds,
                interval.Milliseconds);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }

        if (!paused)
        {
            pauseMenu.SetActive(false);
        }
    }
}
