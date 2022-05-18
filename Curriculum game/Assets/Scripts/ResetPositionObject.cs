using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionObject : MonoBehaviour
{
    public ResetControll rc;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(rc.isReset){
            transform.position = startPosition;
            rc.isReset = false;
        }
    }
}
