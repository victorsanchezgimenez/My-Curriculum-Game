using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public FollowCharacter followCharacter;
    public GameObject virtualCamera;


    private void OnTriggerStay(Collider other) 
    {
        if(virtualCamera == null){

            virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
            followCharacter = virtualCamera.GetComponent<FollowCharacter>();
        }


        if(other.gameObject.tag == "ChangeCamera")
        {
            followCharacter.normalCamera = false;
            followCharacter.zoomCamera = false;
            followCharacter.normalCameraTwo = false;
            followCharacter.changeCamera = true;
        }

        if(other.gameObject.tag == "NormalCamera")
        {
            followCharacter.changeCamera = false;
            
            if(followCharacter.zoomCamera == true)
            {
                Debug.Log("Entrando zoomback");
                followCharacter.zoomCamera = false;
                followCharacter.normalCameraTwo = true;
            }
            else
            {
                //followCharacter.zoomCamera = false;
                followCharacter.normalCameraTwo = false;
                followCharacter.normalCamera = true;
            }
            

        }

        if(other.gameObject.tag == "ZoomCamera")
        {
            followCharacter.changeCamera = false;
            followCharacter.normalCamera = false;
            followCharacter.normalCameraTwo = false;
            followCharacter.zoomCamera = true;
        }
    }
    
}
