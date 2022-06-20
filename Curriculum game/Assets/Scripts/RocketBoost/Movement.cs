using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 2f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    Rigidbody rb;
    AudioSource audioSource;
    private ChangeLevel changeLevel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        changeLevel = GameObject.FindGameObjectWithTag("LevelController").GetComponent<ChangeLevel>();
    }

    void Update()
    {
        if(changeLevel.panelIsOpen == false){

            ProcessThrust();
            ProcessRotation();
        }
    }


    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }
    private void StartThrust()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);

        }
        if (!mainEngineParticles.isPlaying)
        {

            mainEngineParticles.Play();
            rightEngineParticles.Play();
            leftEngineParticles.Play();
        }
    }
    private void StopThrust()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }


        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
