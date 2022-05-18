using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    private GameObject characterController;
    public Animator animator;
    Scene scene;

    private int levelToLoad;
    public bool isChanging = false;

    void Start() 
    {
        scene = SceneManager.GetActiveScene();
        characterController = GameObject.FindGameObjectWithTag("PlayerController");
        characterController.GetComponent<CharacterController>().sceneOne = false;
    }
    
    void Update() 
    {
        if(isChanging && scene.name == "MainScene"){
            FadeToLevel(1);
            
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
