using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MonoBehaviour playerMovement; // Reference to the player's movement script (the component that controls movement)
    public GameObject menuUI; // Reference to the Canvas GameObject containing the menu UI
    public GameObject panelUI; // Reference to the panel GameObject that should be activated/deactivated

    private bool isMenuActive = true;
    private bool isPanelActive = false;
    private float previousTimeScale;

    private void Start()
    {
        // Initially, disable the player's movement script and activate the menu
        playerMovement.enabled = false;
        menuUI.SetActive(true);
        panelUI.SetActive(false); // Deactivate the panel
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f; // Stop the time

        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void StartGame()
    {
        isMenuActive = false;
        ToggleMenu();
    }

    public void TogglePanel()
    {
        isPanelActive = !isPanelActive;
        panelUI.SetActive(isPanelActive);

        // Adjust the game state based on panel activation
        if (isPanelActive)
        {
            Time.timeScale = 0f; // Stop the time
            playerMovement.enabled = false;
        }
        else
        {
            Time.timeScale = previousTimeScale; // Restore the previous time scale
            playerMovement.enabled = true;
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

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
