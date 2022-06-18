using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayInvoke = 1.5f;
    [SerializeField] AudioClip soundSuccess;
    [SerializeField] AudioClip soundCrash;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    AudioSource audioSource;
    private GameObject player;
    private ChangeLevel changeLevel;
    private Animator animator;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        changeLevel = GameObject.FindGameObjectWithTag("LevelController").GetComponent<ChangeLevel>();
        animator = GameObject.FindGameObjectWithTag("LevelController").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update() 
    {
        

        RespondToDebugKey();

        Debug.Log(player);
    }

    void RespondToDebugKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled){ return; }

        switch(other.gameObject.tag)
        {
            case "Friendly":
                break;

            case "Finish":
                StartNextLevelSequence();
                break;

            case "Fuel":
                break;

            default:
                StartCrashSequence();
                break;
            }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(soundCrash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayInvoke);
    }

    void StartNextLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(soundSuccess);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delayInvoke);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            player.SetActive(true);
            nextSceneIndex = 0;
        }
        animator.SetBool("FadeIn", false);
        changeLevel.FadeToLevel(nextSceneIndex);
        //SceneManager.LoadScene(nextSceneIndex);

    }  
}
