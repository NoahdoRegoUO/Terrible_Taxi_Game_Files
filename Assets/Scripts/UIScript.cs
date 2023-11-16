using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text speedText;
    public Text timeText;
    public Text destinationText;

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
    }
}
