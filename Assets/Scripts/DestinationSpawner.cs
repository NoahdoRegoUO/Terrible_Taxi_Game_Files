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

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
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

        time = 60f;

        DestinationPointer.Instance().activate();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (CarController.occupied && other.tag == "Player")
        {
            Debug.Log("Sucessful drop off");
            CarController.occupied = false;
            DestinationPointer.Instance().deactivate();
            gameObject.SetActive(false);
        }
    }
}
