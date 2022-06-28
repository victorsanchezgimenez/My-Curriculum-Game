using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    Scene scene;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }
    void Update()
    {
        if(scene.name == null)
        {
            scene = SceneManager.GetActiveScene();
            if (scene.name == "StarCraftBattle" || scene.name == "TowerDefense" || scene.name == "RocketBoost" || scene.name == "RocketBoost2" || scene.name == "RocketBoost3")
            {

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        Debug.Log(scene.name);
        
    }
}
