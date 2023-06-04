using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MonoBehaviour playerMovement; // Reference to the player's movement script (the component that controls movement)
    public MonoBehaviour cameraMovement; // Reference to the camera's movement script (the component that controls camera movement)
    public Canvas menuCanvas; // Reference to the Canvas component containing the menu UI
    public GameObject[] panelUIs; // References to the panel GameObjects that should be activated/deactivated

    private bool isMenuActive = true;
    private int activePanelIndex = 0;
    private bool isCameraMovementEnabled = false;

    private void Start()
    {
        // Initially, disable the player's movement script and activate the menu
        playerMovement.enabled = false;
        cameraMovement.enabled = false;
        menuCanvas.gameObject.SetActive(true);
        SetPanelActive(activePanelIndex);

        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void StartGame()
    {
        isMenuActive = false;
        ToggleMenu();
        EnablePlayerMovement(); // Enable player movement when the game starts
    }

    public void TogglePanel()
    {
        activePanelIndex++;
        if (activePanelIndex >= panelUIs.Length)
        {
            activePanelIndex = 0;
        }

        SetPanelActive(activePanelIndex);

        // Adjust the game state based on panel activation
        if (activePanelIndex == 0)
        {
            EnablePlayerMovement(); // Enable player movement when the first panel is active
        }
        else
        {
            DisablePlayerMovement(); // Disable player movement when other panels are active
        }
    }

    public void QuitGame()
    {
        // Implement your code to quit the game here
        Application.Quit();
        Debug.Log("Closing game...");
    }

    private void ToggleMenu()
    {
        if (isMenuActive)
        {
            menuCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Show the cursor
            Time.timeScale = 0f; // Stop the time
        }
        else
        {
            menuCanvas.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false; // Hide the cursor
            Time.timeScale = 1f; // Resume the time
        }
    }

    private void EnablePlayerMovement()
    {
        playerMovement.enabled = true;
        if (activePanelIndex == 0)
        {
            isCameraMovementEnabled = true;
        }
        Time.timeScale = 1f; // Resume the time
    }

    private void DisablePlayerMovement()
    {
        playerMovement.enabled = false;
        isCameraMovementEnabled = false;
        Time.timeScale = 0f; // Stop the time
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void SetPanelActive(int index)
    {
        for (int i = 0; i < panelUIs.Length; i++)
        {
            panelUIs[i].SetActive(i == index);
        }
    }

    private void Update()
    {
        // Check if the menu canvas is active to freeze/unfreeze time and disable/enable camera movement
        if (menuCanvas.gameObject.activeSelf)
        {
            Time.timeScale = 0f; // Freeze time
            cameraMovement.enabled = isCameraMovementEnabled; // Disable camera movement if necessary
        }
        else
        {
            Time.timeScale = 1f; // Unfreeze time
            cameraMovement.enabled = true; // Enable camera movement when canvas is not active
        }

        // Check if player movement is enabled before allowing movement input
        if (playerMovement.enabled)
        {
            // Handle player movement input code here
        }
    }
}
