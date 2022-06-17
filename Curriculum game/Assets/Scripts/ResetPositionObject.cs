using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionObject : MonoBehaviour
{
    public GameObject[] startPos;
    public Vector3[] resetPos;
    public GameObject resetControll;
    public ResetControll rc;

    void Start()
    {
        resetControll = GameObject.FindGameObjectWithTag("ResetController");
        rc = resetControll.GetComponent<ResetControll>();
        Debug.Log(resetPos.Length);
        Debug.Log(startPos.Length);
        for(int i = 0 ; i < startPos.Length ; ++i)
        {
            resetPos[i] = startPos[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rc.isReset){

           for (int i = 0 ; i < startPos.Length ; ++i)
            {
                startPos[i].transform.position = resetPos[i];
            }
            rc.isReset = false;
        }
    }
}
