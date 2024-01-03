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
    public TextMeshProUGUI grade;
    public TextMeshProUGUI desc;
    public static bool setupFlag = false;
    private float timeScore;


    public void Setup()
    {
        time.text = "Time: " + GameController.GetGameTime();
        timeScore = Time.timeSinceLevelLoad;
        switch (timeScore)
        {
            case < 105:
                grade.text = "A";
                grade.color = new Color32(76, 224, 79, 225);
                desc.text = "Job well done";
                break;
            case < 150:
                grade.text = "B";
                grade.color = new Color32(59, 157, 225, 225);
                desc.text = "Not bad... for a rookie";
                break;
            case < 180:
                grade.text = "C";
                grade.color = new Color32(224, 210, 76, 225);
                desc.text = "Try driving faster";
                break;
            case < 210:
                grade.text = "D";
                grade.color = new Color32(224, 148, 76, 225);
                desc.text = "Did your car break down?";
                break;
            default:
                grade.text = "F";
                grade.color = new Color32(224, 76, 76, 225);
                desc.text = "Just for that, you owe me $5";
                break;
        }
        setupFlag = false;
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
        if (setupFlag && GameController.gameEnded)
        {
            Setup();
        }
    }
}
