using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wheels;

    [SerializeField]
    private TrailRenderer lTrail;

    [SerializeField]
    private TrailRenderer rTrail;

    public Animator carAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CarController.speed > 5 && CarController.moveValue == 1)
        {
            carAnimator.SetBool("Driving", true);
        }
        else
        {
            carAnimator.SetBool("Driving", false);
        }

        if (carAnimator.GetBool("Driving") && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            carAnimator.SetBool("Turning Left", true);

            rTrail.emitting = true;
        }
        else
        {
            carAnimator.SetBool("Turning Left", false);

            rTrail.emitting = false;
        }

        if (carAnimator.GetBool("Driving") && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            carAnimator.SetBool("Turning Right", true);

            lTrail.emitting = true;
        }
        else
        {
            carAnimator.SetBool("Turning Right", false);

            lTrail.emitting = false;
        }

        // spin wheels
        foreach (var wheel in wheels)
        {
            wheel.transform.Rotate(CarController.speed, 0, 0, Space.Self);
        }
    }
}
