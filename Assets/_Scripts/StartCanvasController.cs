using UnityEngine;
using UnityEngine.UI;

public class StartCanvasController : MonoBehaviour
{
    public Canvas firstCanvas;
    public Canvas secondCanvas;
    public Button hideButton;
    public Button panelButton;
    public Button closeButton;
    public Button backButton; // new button for going back to the first canvas

    private bool canvasActive = true;
    private bool playerWasFrozen = false;

    private void Start()
    {
        Time.timeScale = 1; // Start with normal time scale
        firstCanvas.gameObject.SetActive(canvasActive); // Show first canvas on start
        hideButton.onClick.AddListener(HideCanvas);
        panelButton.onClick.AddListener(NextCanvas);
        closeButton.onClick.AddListener(CloseGame);
        backButton.onClick.AddListener(BackToFirstCanvas); // assign the new button's method

        // Freeze the player's movement
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            FirstPersonMovement playerController = player.GetComponent<FirstPersonMovement>();
            playerController.enabled = false;

            // Freeze the camera's movement
            FirstPersonLook cameraController = player.GetComponentInChildren<FirstPersonLook>();
            if (cameraController != null)
            {
                cameraController.enabled = false;
            }
        }
    }

    private void HideCanvas()
    {
        canvasActive = !canvasActive;
        firstCanvas.gameObject.SetActive(canvasActive);
        secondCanvas.gameObject.SetActive(false);
        if (canvasActive)
        {
            playerWasFrozen = Time.timeScale == 0;
            Time.timeScale = 0; // Stop time when canvas is active
        }
        else
        {
            Time.timeScale = 1; // Restore normal time scale

            // Unfreeze the player's movement
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                FirstPersonMovement playerController = player.GetComponent<FirstPersonMovement>();
                playerController.enabled = true;

                // Unfreeze the camera's movement
                FirstPersonLook cameraController = player.GetComponentInChildren<FirstPersonLook>();
                if (cameraController != null)
                {
                    cameraController.enabled = true;
                }
            }
        }
    }

    private void NextCanvas()
    {
        if (firstCanvas.gameObject.activeSelf)
        {
            firstCanvas.gameObject.SetActive(false);
            secondCanvas.gameObject.SetActive(true);
        }
        else
        {
            firstCanvas.gameObject.SetActive(true);
            secondCanvas.gameObject.SetActive(false);
        }
    }

    private void BackToFirstCanvas()
    {
        secondCanvas.gameObject.SetActive(false);
        firstCanvas.gameObject.SetActive(true);
    }

    private void CloseGame()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        // Unfreeze the player's movement
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {   
            FirstPersonMovement playerController = player.GetComponent<FirstPersonMovement>();
            playerController.enabled = true;

            // Unfreeze the camera's movement
            FirstPersonLook cameraController = player.GetComponentInChildren<FirstPersonLook>();
            if (cameraController != null)
            {
                cameraController.enabled = true;
            }
        }
    }
}
