using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndingScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Unlock and show the mouse cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Load the "Ending" scene
            SceneManager.LoadScene("Ending");
        }
    }
}
