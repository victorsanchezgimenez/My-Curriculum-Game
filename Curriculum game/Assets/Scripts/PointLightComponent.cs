using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightComponent : MonoBehaviour
{
    

    public Animator animator;
    private GameObject platformDay;
    private CicleNight cicleNight;
     
    void Start()
    {
        platformDay = GameObject.FindGameObjectWithTag("PlatformDay");
        cicleNight = platformDay.GetComponent<CicleNight>();
    }

    void Update()
    {
        if(cicleNight.isNight)
        {
            Debug.Log("Enter");
            animator.SetBool("isNight", true);
        }
        else
        {
            animator.SetBool("isNight", false);    
        }
    }
}
