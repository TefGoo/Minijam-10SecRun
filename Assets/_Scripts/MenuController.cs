using UnityEngine;

public class MenuController : MonoBehaviour
{
    public MonoBehaviour playerMovement; // Reference to the player's movement script (the component that controls movement)
    public GameObject menuUI; // Reference to the Canvas GameObject containing the menu UI

    private bool isMenuActive = true;
    private float previousTimeScale;

    private void Start()
    {
        // Initially, disable the player's movement script and activate the menu
        playerMovement.enabled = false;
        menuUI.SetActive(true);
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f; // Stop the time
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Adjust the input key according to your preference
        {
            isMenuActive = !isMenuActive;
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (isMenuActive)
        {
            Time.timeScale = 0f; // Stop the time
            playerMovement.enabled = false;
            menuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Show the cursor
        }
        else
        {
            Time.timeScale = previousTimeScale; // Restore the previous time scale
            playerMovement.enabled = true;
            menuUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false; // Hide the cursor
        }
    }

    public void ResumeGame()
    {
        isMenuActive = false;
        ToggleMenu();
    }

    public void QuitGame()
    {
        // Implement your code to quit the game here
        Application.Quit();
    }
}
