using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicleNight : MonoBehaviour
{

    public Transform lightComponent;
    public Quaternion offsetRotation;
    private Quaternion startRotationPosition;
    [SerializeField][Range(0,2)] float movementSpeed;
    [HideInInspector]
    public bool isNight = false;


    void Start()
    {
        lightComponent = GameObject.FindGameObjectWithTag("Light").transform;
        startRotationPosition = lightComponent.transform.rotation;

    }

    private void FixedUpdate() 
    {

        if(isNight)
        {
            
            lightComponent.rotation = Quaternion.Slerp(lightComponent.transform.rotation, offsetRotation, movementSpeed * Time.deltaTime);
        }
        if(!isNight){

            lightComponent.rotation = Quaternion.Slerp(lightComponent.rotation, startRotationPosition, movementSpeed * Time.deltaTime);
        }

        
    }
    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            if(!isNight){
                isNight = true;

            }
            else{
                isNight = false;
            }

        }
        
    }
}
