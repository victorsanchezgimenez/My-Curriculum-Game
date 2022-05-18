using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    public static MovementCar instance;

    [SerializeField] float acceleration = 800f;
    [SerializeField] float maxTurnAngle = 100f;


    Rigidbody rb;

    private float currentAcceleration = 0f;
    private float currentTurnAngle = 0f;

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    DontDestroyOnLoad(gameObject);
    }

    void Start() 
    {

        rb = GetComponent<Rigidbody>();
    }
    

    private void FixedUpdate() 
    {

        
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");
        //Get forward/reverse acceleration from vertical axis
        currentAcceleration = acceleration * inputVertical;
        rb.AddRelativeForce(Vector3.forward * currentAcceleration * Time.deltaTime);   
        
        //Take care of the steering
        currentTurnAngle = maxTurnAngle * inputHorizontal;
        rb.AddRelativeForce(Vector3.right * currentTurnAngle * Time.deltaTime);
        
    }

}
