using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] destinations;

    public static float time;
    private int spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
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
        spawnLocation = Random.Range(0, destinations.Length);

        gameObject.transform.position = destinations[spawnLocation].transform.position;

        time = 60f;

        gameObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        Spawn();
    }
}
