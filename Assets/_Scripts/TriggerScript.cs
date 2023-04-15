using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    public GameObject gameTriggerToActivate;
    public GameObject soundObject; // reference to the object with the AudioSource component

    private void Start()
    {
        gameObjectToActivate.SetActive(false);
        gameTriggerToActivate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObjectToActivate.SetActive(true);
            gameTriggerToActivate.SetActive(true);
            Debug.Log("Trigger activated");

            // Play the sound effect
            AudioSource audioSource = soundObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
