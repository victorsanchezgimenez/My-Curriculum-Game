using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticles : MonoBehaviour
{
    public GameObject ps;
    private ParticleSystem psc;

    void Start()
    {
        psc = ps.GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            psc.Play();
        }

    }

    private void OnTriggerExit(Collider other) 
    {
         if (other.gameObject.tag == "Player")
        {
            psc.Stop();
        }
    }
}
