using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI destinationText;
    public TextMeshProUGUI pedestrianText;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Change to setters to prevent constant checking in update method
        speedText.text = ((int)CarController.speed * 2).ToString();
        timeText.text = ((int)DestinationSpawner.time).ToString();
        destinationText.text = DestinationSpawner.destinationName;
        pedestrianText.text = GameController.GetPedestrianCount().ToString();
        timerText.text = GameController.GetGameTime();
    }
}
