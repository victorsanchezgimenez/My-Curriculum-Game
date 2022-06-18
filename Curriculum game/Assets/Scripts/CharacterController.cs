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
    [SerializeField] MeshRenderer[] renderers = null;
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
        if(scene.name == null)
        {
            scene = SceneManager.GetActiveScene();
        }

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if(scene.name == "MainScene")
        {
            if(!sceneOne){
            
                player.GetComponent<MovementCharacter>().enabled = true;
                foreach(var renderer in renderers){
                    renderer.enabled = true;
                }
                
                sceneOne = true;
                internController = false;
            }
        }else{
            
            if(!internController)
            {
                player.GetComponent<MovementCharacter>().enabled = false;
                foreach(var renderer in renderers){
                    renderer.enabled = false;
                }
                currentPosition = player.transform.position;
                sceneOne = false;
                scene = SceneManager.GetActiveScene();
                internController = true;
            }
        }

    } 
}
