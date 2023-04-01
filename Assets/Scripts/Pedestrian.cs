using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : MonoBehaviour
{
    public bool inCar;
    public float walkSpeed;
    public float walkTime;


    NavMeshAgent agent;
    private float yBounceOffset;
    private float yBounceFreq;

    public Transform[] waypoints;
    int waypointIndex;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        //Set position to random waypoint and iterate waypoint
        int tmpRand = Random.Range(0, waypoints.Length - 1);
        transform.position = new Vector3(waypoints[tmpRand].transform.position.x, waypoints[tmpRand].transform.position.y, waypoints[tmpRand].transform.position.z);
        waypointIndex = tmpRand;
        IterateWaypointIndex();

        yBounceOffset = Random.Range(0, 1);
        yBounceFreq = Random.Range(2, 4);
        
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Equation for setting y position (walk bounce)
        float yPos = (-1 * Mathf.Pow((float)-0.5 + ((yBounceFreq * Time.time - yBounceOffset) % 1), 2) + (float)1.1);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        if (Vector3.Distance(transform.position, target) < 2)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !CarController.occupied)
        {
            CarController.occupied = true;
            DestinationSpawner.Instance().activate();
            gameObject.SetActive(false);
        }
    }
}
