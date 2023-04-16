using SojaExiles;
using UnityEngine;

public class FinalInteract : MonoBehaviour
{
    public AudioClip interactSound;
    public GameObject canvasObject; // Reference to the canvas object to be displayed
    public FirstPersonMovement playerMovement; // Reference to the player movement script/component

    private bool isCanvasDisplayed = false; // Flag to keep track of whether the canvas is displayed or not

    public void Start()
    {
        canvasObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isCanvasDisplayed) // If the canvas is not already displayed
            {
                AudioSource.PlayClipAtPoint(interactSound, transform.position);
                canvasObject.SetActive(true); // Display the canvas
                isCanvasDisplayed = true; // Set the flag to true
                playerMovement.enabled = false; // Disable player movement
            }
        }
    }

    // Disable the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasObject.SetActive(false); // Hide the canvas
            isCanvasDisplayed = false; // Set the flag to false
            GetComponent<Collider>().enabled = false;
            playerMovement.enabled = true; // Enable player movement
        }
    }
}
