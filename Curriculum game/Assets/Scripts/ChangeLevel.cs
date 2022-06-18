using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public static ChangeLevel instance;
    private GameObject characterController;
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;
    public Animator animator;
    Scene scene;

    private int levelToLoad;
    public bool isChanging = false;

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

    DontDestroyOnLoad(gameObject);
    }

    void Start() 
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "MainScene"){
            levelOne = GameObject.FindGameObjectWithTag("LevelOne");
            levelTwo = GameObject.FindGameObjectWithTag("LevelTwo");
            levelThree = GameObject.FindGameObjectWithTag("LevelThree");
        }

        characterController = GameObject.FindGameObjectWithTag("PlayerController");
        characterController.GetComponent<CharacterController>().sceneOne = false;
        

    }
    
    void Update() 
    {
        if(scene.name == null){
            Debug.Log("Entering here");
            scene = SceneManager.GetActiveScene();
        }

        if(levelOne == null || levelTwo == null || levelThree == null)
        {
            levelOne = GameObject.FindGameObjectWithTag("LevelOne");
            levelTwo = GameObject.FindGameObjectWithTag("LevelTwo");
            levelThree = GameObject.FindGameObjectWithTag("LevelThree");
        }

        Debug.Log(scene.name);
        if(isChanging && scene.name == "MainScene")
        {
            if(levelOne.GetComponent<EnterLevel>().levelSelected == 1)
            {
                Debug.Log("Enter Level 1");
                animator.SetBool("FadeIn", false);
                FadeToLevel(1);

            }
            else if (levelTwo.GetComponent<EnterLevel>().levelSelected == 2)
            {
                Debug.Log("Enter Level 2");
                animator.SetBool("FadeIn", false);
                FadeToLevel(2);

            }
            else if (levelThree.GetComponent<EnterLevel>().levelSelected == 3)
            {
                Debug.Log("Enter Level 3");
                animator.SetBool("FadeIn", false);
                FadeToLevel(3);

            }
            
        }

        else if(isChanging && Input.GetKeyDown(KeyCode.Escape) && scene.name == "RocketBoost")
        {
            Debug.Log("Cambiando A nivel 1");
            animator.SetBool("FadeIn", false);
            FadeToLevel(0);
        }

    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetBool("FadeOut", true);
        
        
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetBool("FadeOut", false);
        StartCoroutine(DelayAction());

        
    }

    IEnumerator DelayAction()
{
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("FadeIn", true);
}
}
