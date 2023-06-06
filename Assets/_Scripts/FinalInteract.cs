using UnityEngine;

public class FinalInteract : MonoBehaviour
{
    public Canvas uiCanvas;
    public GameObject playerCamera;
    public GameObject secondPanel;
    public float delayToShowPanel = 3f;

    private bool hasTriggered = false;
    private bool isCanvasActive = false;
    private float triggerTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // Activate the UI canvas
            uiCanvas.enabled = true;
            isCanvasActive = true;

            // Disable player movement
            FirstPersonMovement playerMovement = other.GetComponent<FirstPersonMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            // Disable camera movement
            FirstPersonLook playerLook = playerCamera.GetComponent<FirstPersonLook>();
            if (playerLook != null)
            {
                playerLook.DisableCameraMovement();
            }

            // Unlock the cursor and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Set the trigger time to delay the second panel
            triggerTime = Time.time;

            // Set the trigger flag to prevent repeated triggering
            hasTriggered = true;
        }
    }

    private void Update()
    {
        // Check if the canvas is active and it's time to show the second panel
        if (isCanvasActive && Time.time >= triggerTime + delayToShowPanel)
        {
            // Show the second panel
            secondPanel.SetActive(true);

            // Unlock mouse movement and hide cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Enable player movement and camera rotation
            FirstPersonMovement playerMovement = GetComponent<FirstPersonMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = true;
            }

            FirstPersonLook playerLook = playerCamera.GetComponent<FirstPersonLook>();
            if (playerLook != null)
            {
                playerLook.EnableCameraMovement();
            }

            // Set the timescale back to 1
            Time.timeScale = 1f;
        }
    }
}
