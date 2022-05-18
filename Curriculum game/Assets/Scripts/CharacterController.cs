using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController instance;
    private GameObject player;
    [HideInInspector]
    public bool sceneOne = false;
    private bool internController = false;
    [HideInInspector]
    public bool anotherController = false;
    Scene scene;

    private Vector3 currentPosition;

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
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
        if(anotherController)
        {
            scene = SceneManager.GetActiveScene();
            anotherController = false;
        }
        
        if(scene.name == "MainScene")
        {
            if(!sceneOne){
                player.SetActive(true);
                sceneOne = true;
                internController = false;
                anotherController = false;
            }
        }else{
            
            if(!internController)
            {
                player.SetActive(false);
                currentPosition = player.transform.position;
                sceneOne = false;
                scene = SceneManager.GetActiveScene();
                internController = true;
            }
        }

    } 
}
