using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPointer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;

        targetPos.y = transform.position.y;

        transform.LookAt(targetPos);

    }
}
