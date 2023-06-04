using UnityEngine;

public class CameraActivation : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas containing the menu UI
    public FirstPersonLook firstPersonLook; // Reference to the FirstPersonLook script

    private void Start()
    {
        // Enable the FirstPersonLook script by default
        EnableFirstPersonLook();
    }

    private void Update()
    {
        // Check if the canvas is active to enable/disable the FirstPersonLook script
        if (canvas.gameObject.activeSelf)
        {
            DisableFirstPersonLook();
        }
        else
        {
            EnableFirstPersonLook();
        }
    }

    private void EnableFirstPersonLook()
    {
        firstPersonLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }

    private void DisableFirstPersonLook()
    {
        firstPersonLook.enabled = false;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }
}
