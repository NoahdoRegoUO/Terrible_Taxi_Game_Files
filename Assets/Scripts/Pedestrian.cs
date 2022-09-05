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

    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //if (walkTime > 0)
        //{
        //    gameObject.transform.Translate(new Vector3(0, -1, 0) * walkSpeed);

        //    walkTime -= Time.deltaTime;
        //}
        //else
        //{
        //    walkTime = Random.Range(5.0f, 15.0f);
        //    TurnRandom();
        //}

        if (Vector3.Distance(transform.position, target) < 1)
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

    void TurnRandom()
    {
        //transform.eulerAngles = new Vector3(0, 90 * Random.Range(0, 3), 0);
    }
}
