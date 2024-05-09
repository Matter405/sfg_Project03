using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingRandomizer : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips (1-maxAudioClips)
    public int maxAudioClips = 6;
    private int previousNumber = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            int newNumber;
            do
            {
                newNumber = Random.Range(1, (maxAudioClips+1)); // Generate between 1 (inclusive) and 7 (exclusive)
            } while (newNumber == previousNumber);

            previousNumber = newNumber;
            Debug.Log("Generated number: " + newNumber);
            PlayAudioClip(newNumber - 1); // Adjust index for 0-based array
        }
    }

    void PlayAudioClip(int index)
    {
        Debug.Log("Playing Audio");
        /*if (audioSource.isPlaying)
        {
            return; // Don't play if previous audio is still playing
        }

        audioSource.clip = audioClips[index];
        audioSource.Play();*/
    }
 }
