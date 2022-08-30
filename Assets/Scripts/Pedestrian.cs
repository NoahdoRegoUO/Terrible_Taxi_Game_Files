using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public bool inCar;
    public float walkSpeed;
    public float walkTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (walkTime > 0)
        {
            gameObject.transform.Translate(new Vector3(0, -1, 0) * walkSpeed);

            walkTime -= Time.deltaTime;
        }
        else
        {
            walkTime = Random.Range(5.0f, 15.0f);
            TurnRandom();
        }
    }

    void TurnRandom()
    {
        //transform.eulerAngles = new Vector3(0, 90 * Random.Range(0, 3), 0);
    }
}
