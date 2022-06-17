using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    private GameObject characterController;
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;
    public Animator animator;
    Scene scene;

    private int levelToLoad;
    public bool isChanging = false;

    void Start() 
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "MainScene"){
            Debug.Log("HOLA GHOLA");
            levelOne = GameObject.FindGameObjectWithTag("LevelOne");
            levelTwo = GameObject.FindGameObjectWithTag("LevelTwo");
            levelThree = GameObject.FindGameObjectWithTag("LevelThree");
        }

        characterController = GameObject.FindGameObjectWithTag("PlayerController");
        characterController.GetComponent<CharacterController>().sceneOne = false;
        

    }
    
    void Update() 
    {

        if(isChanging && scene.name == "MainScene")
        {
            if(levelOne.GetComponent<EnterLevel>().levelSelected == 1)
            {
                Debug.Log("Enter Level 1");
                FadeToLevel(1);

            }
            else if (levelTwo.GetComponent<EnterLevel>().levelSelected == 2)
            {
                Debug.Log("Enter Level 2");
                FadeToLevel(2);

            }
            else if (levelThree.GetComponent<EnterLevel>().levelSelected == 3)
            {
                Debug.Log("Enter Level 3");
                FadeToLevel(3);

            }
            
        }

        else if(!isChanging && Input.GetKeyDown(KeyCode.Escape) && scene.name == "RocketBoost")
        {
            FadeToLevel(0);
        
        }

    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        characterController.GetComponent<CharacterController>().anotherController = true;
    }
}
