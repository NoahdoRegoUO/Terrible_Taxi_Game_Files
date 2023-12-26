using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int pedestrianCount;
    private double timeTaken;
    private static string timeDisplay;
    private static bool gameEnded = false;

    public static GameObject gameOverScreen;

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

    void Start()
    {
        pedestrianCount = 10;
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
        GameOverScreen.timeFlag = true;
        gameOverScreen.SetActive(false);
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
    }
}
