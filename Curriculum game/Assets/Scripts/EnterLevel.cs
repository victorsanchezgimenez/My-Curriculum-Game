using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public ChangeLevel changeLevelScript;
    public bool isInside = false;

    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            changeLevelScript.isChanging = true;
            Debug.Log(isInside);

        }
    }

}
