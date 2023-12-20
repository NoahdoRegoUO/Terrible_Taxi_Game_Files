using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Types
    enum PowerType
    {
        Boost,
        Freeze,
        Bomb
    }

    public GameObject pickupEffect;

    [SerializeField]
    private GameObject[] locations;
    private PowerType power;
    private Transform visual;

    void Start()
    {
        power = PowerType.Boost;

        int tmpRand = Random.Range(0, locations.Length - 1);
        transform.position = new Vector3(locations[tmpRand].transform.position.x, locations[tmpRand].transform.position.y, locations[tmpRand].transform.position.z);

        visual = gameObject.transform;
        visual.Rotate(Vector3.forward, -20, Space.World);
        StartCoroutine(FloatAnimation());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        // Feedback
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect
        switch (power)
        {
            case PowerType.Boost:
                CarController.Instance().fwdSpeed = 270;
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }

    private IEnumerator FloatAnimation()
    {
        while (gameObject.activeSelf)
        {
            visual.Rotate(Vector3.up, 60 * Time.deltaTime, Space.World);
            visual.position = new Vector3(transform.position.x, Mathf.Sin(Time.time) * 0.5f + 1, transform.position.z);
            yield return null;
        }
    }
}
