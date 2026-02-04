using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    [SerializeField] float thrustPower = 500;
    [SerializeField] float rotationPower = 100;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    
    AudioSource audioSource;
    Rigidbody rb;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    void OnEnable() 
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * Time.fixedDeltaTime * thrustPower);
            if(!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSFX);
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
        float rotationInput = rotation.ReadValue<float>();  
        
        if(rotationInput > 0)
        {
            if(!leftThrustParticles.isPlaying)
            {
                leftThrustParticles.Play();
            }
            ApplyRotation(-rotationPower);
        }
        else if(rotationInput < 0)
        {
            if(!rightThrustParticles.isPlaying)
            {
                rightThrustParticles.Play();
            }
            ApplyRotation(rotationPower);
        }
        else
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Stop();
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
