using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;
    [SerializeField] float sceneDelay = 1f;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;    
    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(!isControllable || !isCollidable) return;
        switch(collision.gameObject.tag)
        {
            case "Hazard":
                StartCrashSequence();
                break;
            case "Finish":
                NextLevelSequence();
                break;
        }
    }
    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void LoadNextLevel()
    {
        int totalScene = SceneManager.sceneCountInBuildSettings;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == totalScene)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
        
    }
    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", sceneDelay);
    }
    void NextLevelSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", sceneDelay);
    }
    void RespondToDebugKeys()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
        }
    }

}
