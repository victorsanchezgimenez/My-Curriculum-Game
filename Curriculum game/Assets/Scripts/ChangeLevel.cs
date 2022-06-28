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
    public GameObject player;
    public Animator animator;
    public GameObject informationPanelGameOne;
    public GameObject informationPanelGameTwo;
    public GameObject informationPanelGameThree;
    Scene scene;

    public bool isChanging = false;
    private int levelToLoad;
    public bool panelIsOpen = false;

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
        informationPanelGameOne.SetActive(false);
        informationPanelGameTwo.SetActive(false);
        informationPanelGameThree.SetActive(false);
        scene = SceneManager.GetActiveScene();
        if(scene.name == "MainScene"){
            levelOne = GameObject.FindGameObjectWithTag("LevelOne");
            levelTwo = GameObject.FindGameObjectWithTag("LevelTwo");
            levelThree = GameObject.FindGameObjectWithTag("LevelThree");
        }

        player = GameObject.FindGameObjectWithTag("Player");
        characterController = GameObject.FindGameObjectWithTag("PlayerController");
        characterController.GetComponent<CharacterController>().sceneOne = false;
        

    }
    
    void Update() 
    {
        Debug.Log(panelIsOpen);
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
                player.GetComponent<MovementCharacter>().enabled = false;
                FadeToLevel(1);

            }
            else if (levelTwo.GetComponent<EnterLevel>().levelSelected == 4)
            {
                Debug.Log("Enter Level 2");
                animator.SetBool("FadeIn", false);
                player.GetComponent<MovementCharacter>().enabled = false;

                FadeToLevel(4);

            }
            else if (levelThree.GetComponent<EnterLevel>().levelSelected == 5)
            {
                Debug.Log("Enter Level 3");
                animator.SetBool("FadeIn", false);
                player.GetComponent<MovementCharacter>().enabled = false;
                FadeToLevel(5);

            }
            
        }

        if(isChanging && Input.GetKeyDown(KeyCode.R) && (scene.name == "RocketBoost" || scene.name == "RocketBoost2" || scene.name == "RocketBoost3" || scene.name == "TowerDefense" || scene.name == "StarCraftBattle"))
        {
            Debug.Log("Cambiando A nivel 1");
            if(informationPanelGameTwo.activeSelf == true || informationPanelGameOne.activeSelf == true || informationPanelGameThree.activeSelf == true)
            {
                Time.timeScale = 1;
                informationPanelGameOne.SetActive(false);
                informationPanelGameTwo.SetActive(false);
                informationPanelGameThree.SetActive(false);
                panelIsOpen = false;
            }
            animator.SetBool("FadeIn", false);
            FadeToLevel(0);
        }

        if(scene.name == "RocketBoost" || scene.name == "RocketBoost2" || scene.name == "RocketBoost3"){

            if(Input.GetKeyDown(KeyCode.I))
            {
                if (panelIsOpen)
                {
                    Time.timeScale = 1;
                    informationPanelGameOne.SetActive(false);
                    panelIsOpen = false;

                }
                else
                {
                    Time.timeScale = 0;
                    informationPanelGameOne.SetActive(true);
                    panelIsOpen = true;

                }
            }
        }

        if(scene.name == "TowerDefense")
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log(panelIsOpen);
                if(panelIsOpen)
                {
                    Debug.Log("Entrando a desactivar pantalla");
                    Time.timeScale = 1;
                    informationPanelGameTwo.SetActive(false);
                    panelIsOpen = false;
                }
                else
                {
                    Debug.Log("Entrando EN ESTE OTRO");
                    Time.timeScale = 0;
                    informationPanelGameTwo.SetActive(true);
                    panelIsOpen = true;
                }
            }
        }

        if(scene.name == "StarCraftBattle")
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log(panelIsOpen);
                if(panelIsOpen)
                {
                    Debug.Log("Entrando a desactivar pantalla");
                    Time.timeScale = 1;
                    informationPanelGameThree.SetActive(false);
                    panelIsOpen = false;
                }
                else
                {
                    Debug.Log("Entrando EN ESTE OTRO");
                    Time.timeScale = 0;
                    informationPanelGameThree.SetActive(true);
                    panelIsOpen = true;
                }
            }
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
        yield return new WaitForSeconds(2.0f);
        if(scene.name == "RocketBoost"){
            Time.timeScale = 0;
            informationPanelGameOne.SetActive(true);
            panelIsOpen = true;
            
        }
        else if(scene.name == "TowerDefense"){
            Time.timeScale = 0;
            informationPanelGameTwo.SetActive(true);
            panelIsOpen = true;

        }
        else if(scene.name == "StarCraftBattle"){
            Time.timeScale = 0;
            informationPanelGameThree.SetActive(true);
            panelIsOpen = true;

        }

}
}
