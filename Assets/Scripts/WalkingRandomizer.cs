using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingRandomizer : MonoBehaviour
{
    public AudioClip[] woodAudioClips;
    public AudioClip[] gravelAudioClips;
    public int maxAudioClips = 6;
    private int previousNumber = 0;
    private AudioSource audioSource;
    [SerializeField] private DetectPlane detectPlane;
    private string planeName;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        planeName = detectPlane.GetPlaneName();
        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            int newNumber;
            do
            {
                newNumber = Random.Range(1, (maxAudioClips+1)); // Generate between 1 and maxAudioClips
            } while (newNumber == previousNumber);

            previousNumber = newNumber;
            Debug.Log("Generated number: " + newNumber);
            PlayAudioClip(newNumber - 1); // Adjust index for 0-based array
        }
    }

    void PlayAudioClip(int index)
    {
        /*if (audioSource.isPlaying)
        {
            return; // Don't play if previous audio is still playing
        }*/

        if(planeName == "Wood")
        {
            Debug.Log("Playing Wood Audio");
            /*audioSource.clip = woodAudioClips[index];
            audioSource.Play();*/
        }
        else if (planeName == "Gravel")
        {
            Debug.Log("Playing Gravel Audio");
            /*audioSource.clip = gravelAudioClips[index];
            audioSource.Play();*/
        }
    }
 }
