using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSpawner : MonoBehaviour
{

    private static DestinationSpawner _instance;

    [SerializeField]
    private GameObject[] destinations;

    public static float time;
    public static bool active;
    public static string destinationName;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        destinationName = "Out of Service";
        active = false;
        gameObject.SetActive(false);
    }

    public static DestinationSpawner Instance()
    {
        return _instance;
    }

    public bool isActive()
    {
        return gameObject.activeSelf;
    }

    public void activate()
    {
        gameObject.SetActive(true);
        Spawn();
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

    }

    public void Spawn()
    {
        int spawnLocation = Random.Range(0, destinations.Length);

        gameObject.SetActive(true);

        gameObject.transform.position = destinations[spawnLocation].transform.position;

        destinationName = destinations[spawnLocation].name;

        time = 60f;

        DestinationPointer.Instance().activate();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (CarController.occupied && other.tag == "Player")
        {
            Debug.Log("Sucessful drop off");
            CarController.occupied = false;
            destinationName = "";
            time = 0;
            DestinationPointer.Instance().deactivate();
            gameObject.SetActive(false);
            GameController.MinusPedestrian();
            if (GameController.GetPedestrianCount() <= 0)
            {
                GameController.EndGame();
            }
        }
    }
}
