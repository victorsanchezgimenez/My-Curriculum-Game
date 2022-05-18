using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{

    public GameObject player;
    private Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;
    public Animator animator;
    public bool changeCamera = false;
    public bool normalCamera = false;
    public bool zoomCamera = false;
    public bool normalCameraTwo = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vcam = GetComponent<CinemachineVirtualCamera>();
        
    }

    
    void Update()
    {
        
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        tFollowTarget = player.transform;
        vcam.Follow = tFollowTarget;
    
    
        if(changeCamera)
        {
            animator.SetBool("Enter", true);
            animator.ResetTrigger("OffTriggerSpace");
            animator.ResetTrigger("ZoomScapeBack");
            animator.ResetTrigger("ZoomSpace");
            animator.SetTrigger("OnTriggerSpace");
     
        }

        if(normalCamera)
        {
            
            animator.SetBool("Enter", false);
            animator.ResetTrigger("OnTriggerSpace");
            animator.ResetTrigger("ZoomScapeBack");
            animator.ResetTrigger("ZoomSpace");
            animator.SetTrigger("OffTriggerSpace");
            
        }

        if(normalCameraTwo)
        {
            animator.SetBool("Enter", false);
            animator.ResetTrigger("OffTriggerSpace");
            animator.ResetTrigger("OnTriggerSpace");
            animator.ResetTrigger("ZoomSpace");             
            animator.SetTrigger("ZoomScapeBack");
        }

        if(zoomCamera)
        {
            animator.SetBool("Enter", true);
            animator.ResetTrigger("OffTriggerSpace");
            animator.ResetTrigger("OnTriggerSpace");
            animator.ResetTrigger("ZoomScapeBack");
            animator.SetTrigger("ZoomSpace");

        }

        
    }

}
