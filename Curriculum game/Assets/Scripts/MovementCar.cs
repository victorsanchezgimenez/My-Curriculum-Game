using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    
    [SerializeField] float acceleration = 200f;
    [SerializeField] float maxTurnAngle = 5f;


    Rigidbody rb;

    private float currentAcceleration = 0f;
    private float currentTurnAngle = 0f;
    private float stopRotate = 1.5f;

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
        if(rb.velocity.magnitude > stopRotate)
            transform.Rotate(Vector3.up * currentTurnAngle * Time.deltaTime);
        
    }

}
