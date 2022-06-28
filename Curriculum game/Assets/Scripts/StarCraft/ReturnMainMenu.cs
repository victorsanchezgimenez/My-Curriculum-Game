using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    [SerializeField] ChangeLevel changeLevel;
    [SerializeField] Animator animatorChangeLevel;

    Scene scene;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();

    }
    
    void Start()
    {
        changeLevel = GameObject.FindGameObjectWithTag("LevelController").GetComponent<ChangeLevel>();
        animatorChangeLevel = GameObject.FindGameObjectWithTag("LevelController").GetComponent<Animator>();
    }

    void Update()
    {
        if(scene.name == null)
        {
            scene = SceneManager.GetActiveScene();

        }

        if(changeLevel == null)
        {
            changeLevel = GameObject.FindGameObjectWithTag("LevelController").GetComponent<ChangeLevel>();
        }

    
    }

    void OnTriggerEnter(Collider other) {
        animatorChangeLevel.SetBool("FadeIn", false);
        changeLevel.FadeToLevel(0);    
    }
}
