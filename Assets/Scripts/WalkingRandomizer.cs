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
            Debug.Log("Generated number: " + newNumber);

            if (!isPlayingAudio || !audioSource.isPlaying) // Play only if audio is not already playing
            {
                StartCoroutine(PlayAudioClip(newNumber - 1)); // Adjust index for 0-based array
                isPlayingAudio = true;
            }
        }
        else // No key pressed, stop audio
        {
            isPlayingAudio = false;
            audioSource.Stop(); // Ensure audio stops when key is released
        }
    }

    IEnumerator PlayAudioClip(int index)
    {
        if(planeName == "Wood")
        {
            Debug.Log("Playing Wood Audio");
            audioSource.clip = woodAudioClips[index];
            audioSource.Play();
            yield return new WaitForSeconds(3.0f);
        }
        else if (planeName == "Gravel")
        {
            Debug.Log("Playing Gravel Audio");
            /*audioSource.clip = gravelAudioClips[index];
            audioSource.Play();*/
        }
    }
 }
