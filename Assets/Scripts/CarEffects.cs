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

    [SerializeField] private GameObject boostTrail;

    public Animator carAnimator;
    private AudioSource audioSource;
    private float audioPitch = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Disable effects
        boostTrail.SetActive(false);

        // set audio source
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.pitch = audioPitch;
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

        if (CarController.speed * 2 > 100 && !CarController.drifting)
        {
            boostTrail.SetActive(true);
        }
        else
        {
            boostTrail.SetActive(false);
        }

        // spin wheels
        foreach (var wheel in wheels)
        {
            wheel.transform.Rotate(CarController.speed, 0, 0, Space.Self);
        }

        //set audio
        audioPitch = 0.5f + (CarController.speed / 40);
        audioSource.pitch = audioPitch;
    }
}
