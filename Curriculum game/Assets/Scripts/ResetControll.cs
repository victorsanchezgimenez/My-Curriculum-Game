using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetControll : MonoBehaviour
{
    public GameObject structure;

    [HideInInspector]
    public bool isReset = false;

    void Start()
    {

        isReset = false;
        
    }

    private void OnTriggerStay(Collider other) 
    {

        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            isReset = true;
        }


    }
}
