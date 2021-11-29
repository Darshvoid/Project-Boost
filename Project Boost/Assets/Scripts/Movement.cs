using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readibility or speed
    // STATE - private instance (member) variables
    Rigidbody rb;
    [SerializeField]float upwardThrust = 0.1f;
    [SerializeField]float rotationThrust = 0.1f;
    [SerializeField]AudioClip mainEngine;
    [SerializeField]ParticleSystem mainEngineParticles, leftEngineParticles, rightEngineParticles;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessThrust()
    {
       if (Input.GetKey(KeyCode.Space))
       {
           mainEngineParticles.Play();
           rb.AddRelativeForce(Vector3.up * upwardThrust * Time.deltaTime);
           if (!audioSource.isPlaying)
           {
               audioSource.PlayOneShot(mainEngine);
           }   
           
       }
       else 
       {
           mainEngineParticles.Stop();
           audioSource.Stop();
       }
    }

    void ProcessRotation()
    {
       if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotationThrust); 
        }
        else if (Input.GetKey(KeyCode.D))
       {
           ApplyRotation(rotationThrust);
       }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //frezing rotaiton so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take ove
    }
}
