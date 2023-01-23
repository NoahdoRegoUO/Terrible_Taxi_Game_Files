using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPointer : MonoBehaviour
{
    private static DestinationPointer _instance;

    private Transform target;
    const string spawnerName = "Destination Spawn";

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        deactivate();
    }

    public static DestinationPointer Instance()
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
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive())
        {
            target = GameObject.FindGameObjectWithTag("Destination").transform;

            Vector3 targetPos = target.transform.position;

            targetPos.y = transform.position.y;

            transform.LookAt(targetPos);
        }
    }
}
