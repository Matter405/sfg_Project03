using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingRandomizer : MonoBehaviour
{
    public AudioClip[] woodAudioClips;
    public AudioClip[] gravelAudioClips;
    public int totalAudioClips = 6;
    private int previousNumber = 0;
    private AudioSource audioSource;
    [SerializeField] private DetectPlane detectPlane;
    private string planeName;
    private bool isPlayingAudio = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        planeName = detectPlane.GetPlaneName();
        bool anyKeyPressed = Input.GetKey(KeyCode.W) ||
                              Input.GetKey(KeyCode.A) ||
                              Input.GetKey(KeyCode.S) ||
                              Input.GetKey(KeyCode.D);
        Debug.Log(anyKeyPressed);


        if (anyKeyPressed)
        {
            int newNumber;
            do
            {
                newNumber = Random.Range(1, (totalAudioClips+1)); // Generate between 1 and totalAudioClips
            } while (newNumber == previousNumber);

            previousNumber = newNumber;

            if (!isPlayingAudio || !audioSource.isPlaying) // Play only if audio is not already playing
            {
                PlayAudioClip(newNumber - 1); // Adjust index for 0-based array
                isPlayingAudio = true;
            }
        }
        else // No key pressed, stop audio
        {
            isPlayingAudio = false;
            audioSource.Stop(); // Ensure audio stops when key is released
        }

    }

    void PlayAudioClip(int index)
    {
        if(planeName == "Wood")
        {
            audioSource.clip = woodAudioClips[index];
            audioSource.Play();
        }
        else if (planeName == "Gravel")
        {
            audioSource.clip = gravelAudioClips[index];
            audioSource.Play();
        }
    }
 }
