using System.Collections;
using UnityEngine;

public class WindowSoundTrigger : MonoBehaviour
{
    public AudioClip soundToPlay;
    public GameObject soundObject;

    private bool hasPlayedSound = false;

    private void Start()
    {
        hasPlayedSound = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasPlayedSound)
            {
                AudioSource audioSource = soundObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(soundToPlay);
                    hasPlayedSound = true;
                }
            }
        }
        // Disable the trigger
        GetComponent<Collider>().enabled = false;
    }

}
