using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    public bool isChanging = false;
    
    void Update() 
    {
        if(isChanging){
            FadeToLevel(1);
            isChanging = false;
        }

    }

    
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log(levelToLoad);
        Debug.Log("Enter here");
        SceneManager.LoadScene(levelToLoad);
    }
}
