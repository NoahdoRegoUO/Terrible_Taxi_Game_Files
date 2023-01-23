using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Derived from "Arcade Style Car Controller || Unity Tutorial" by SpawnCampGames

    private static CarController _instance;

    private float moveInput;
    public static float turnInput;
    private bool moving;


    public static int moveValue;

    public float zRotation;
    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public float tiltSpeed;

    public Rigidbody sphereRB;

    public Rigidbody carColliderRB;

    public static float speed;

    public static bool occupied;

    [SerializeField] public bool displayOccupied;

    void Start()
    {
        _instance = this;

        // detach sphere + carCollider from car
        sphereRB.transform.parent = null;
        carColliderRB.transform.parent = null;

        occupied = false;
    }

    public static CarController Instance()
    {
        return _instance;
    }

    void Update()
    {
        //update speed var
        speed = (sphereRB.velocity).magnitude;

        //update z rotation
        zRotation = gameObject.transform.localEulerAngles.z;

        //bool for checking speed, sets value to 1 or 0 to allow turning
        if (speed != 0)
        {
            moving = true;

            if (speed > 12)
            {
                revSpeed = 100;
            }
            else
            {
                revSpeed = 100;
            }
        }
        else
        {
            moving = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            turnSpeed = 200; 
        }
        else
        {
            turnSpeed = 150;
        }

        // Check if moving forwards or backwards and sets moveValue accordingly
        if (Input.GetAxis("Vertical") * speed < 0)
        {
            moveValue = -1;
        }
        else if (moving)
        {
            moveValue = 1;
        }
        else
        {
            moveValue = 0;
        }

        //Get input from arrow keys / WASD
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        //adjust speed
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;


        // setting car's position to sphere's position
        transform.position = sphereRB.transform.position;

        //set car's rotation/turning
        float newRotation = turnInput * (speed / 33 * turnSpeed) * Time.deltaTime * moveValue;
        transform.Rotate(0, newRotation, 0, Space.World);

        //Sideways tilt
        if (moving && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {

        }

        if (moving && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {

        }

        //SHLO MO? awwww yeahhhhh (turn into power up later)
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        //check if above ground
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        //Display occupied status (TESTING)
        displayOccupied = occupied;
    }

    private void FixedUpdate()
    {
        // move sphere
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);

        carColliderRB.MoveRotation(transform.rotation);
    }
}
