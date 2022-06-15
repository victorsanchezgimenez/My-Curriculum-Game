using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public static MovementCharacter instance;

    [SerializeField] float acceleration = 800f;
    [SerializeField] float movementUpgrade;
    [SerializeField][Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    
    Rigidbody rb;
    Vector3 startPosition;
    private float currentAccelerationForward = 0f;
    private float currentAccelerationFront = 0f;

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
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    

    private void FixedUpdate() 
    {
        
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        currentAccelerationForward = -acceleration * inputHorizontal;
        rb.AddRelativeForce(Vector3.forward * currentAccelerationForward * Time.deltaTime);   
        
        currentAccelerationFront = acceleration * inputVertical;
        rb.AddRelativeForce(Vector3.right * currentAccelerationFront * Time.deltaTime);
        
        movementUpDown();


    }


    private void movementUpDown()
    {
        float cycles = Time.time / period;
        
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        transform.position = new Vector3 (this.transform.position.x, 0.5f + movementUpgrade * movementFactor, this.transform.position.z);
        
    }

}
