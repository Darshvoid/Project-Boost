using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float upwardThrust = 0.1f;
    [SerializeField]float rotationThrust = 0.1f;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        audioData = GetComponent<AudioSource>();
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
           rb.AddRelativeForce(Vector3.up * upwardThrust * Time.deltaTime);
           if (!audioData.isPlaying)
           {
               audioData.Play();
           }
           
       }
       else 
       {
           audioData.Stop();
       }
    }

    void ProcessRotation()
    {
       if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust); 
        }
        else if (Input.GetKey(KeyCode.D))
       {
           ApplyRotation(-rotationThrust);
       }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //frezing rotaiton so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take over

        
    }
}
