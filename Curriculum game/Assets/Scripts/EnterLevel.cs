using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    private GameObject levelController;
    public ChangeLevel changeLevelScript;
    public int levelSelected;
    public bool isInside = false;

    void Start()
    {
        levelController = GameObject.FindGameObjectWithTag("LevelController");
        changeLevelScript = levelController.GetComponent<ChangeLevel>();

    }

    private void OnTriggerStay(Collider other) {
        
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            switch(gameObject.tag)
            {
                case "LevelOne":
                    levelSelected = 1;
                    break;
                
                case "LevelTwo":
                    levelSelected = 4;
                    break;
                
                case "LevelThree":
                    levelSelected = 5;
                    break;
            }
    
            changeLevelScript.isChanging = true;
        }
    }

}
