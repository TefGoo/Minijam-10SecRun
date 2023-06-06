using UnityEngine;
using System.Collections;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeLeft = 10f; // Starting time for the countdown
    public TMP_Text timerText; // Text object to display the timer
    public AudioClip startSound; // new AudioClip field for the sound played at the start of the timer
    public AudioClip soundEffect; // Sound effect to play when the timer hits zero
    public Canvas gameOverCanvas; // Canvas object to display when the timer hits zero
    private bool isTimerRunning = false; // Flag to check if the timer is currently running
    private AudioSource audioSource; // Audio source component to play the sound effect

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the audio source component from the game object
        gameOverCanvas.gameObject.SetActive(false); // Hide the game over canvas object at start
        timerText.gameObject.SetActive(false); // Hide the timer text object at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTimerRunning) // Check if the player entered the trigger and the timer is not currently running
        {
            isTimerRunning = true; // Set the flag to true to indicate that the timer is running
            gameOverCanvas.gameObject.SetActive(false); // Hide the game over canvas object
            timerText.gameObject.SetActive(true); // Show the timer text object
            // Play the start sound
            if (startSound != null)
            {
                audioSource.PlayOneShot(startSound);
            }
            StartCoroutine(Countdown()); // Start the countdown
        }
        // Disable the trigger
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0) // Keep looping while there is still time left on the countdown
        {
            timerText.text = timeLeft.ToString("F1"); // Display the time left on the UI text object
            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before continuing
            timeLeft -= 0.1f; // Subtract 0.1 seconds from the time left
        }

        if (soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
        // Play the sound effect when the countdown reaches zero
        gameOverCanvas.gameObject.SetActive(true); // Activate the game over canvas object
        yield return new WaitForSeconds(2f); // Wait for 2 seconds before restarting the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); // Restart the scene
    }

}

