using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI time;
    public static bool timeFlag = false;

    public void Setup()
    {
        time.text = "Time: " + GameController.GetGameTime();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (timeFlag)
        {
            Setup();
            timeFlag = false;
        }
    }
}
