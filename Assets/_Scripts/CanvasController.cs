using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvasObject;
    public FirstPersonMovement playerMovementScript;

    void Start()
    {
        canvasObject.SetActive(false);
        playerMovementScript.enabled = true;
    }

    void Update()
    {

        
            if (canvasObject.activeSelf)
            {
                canvasObject.SetActive(false);
                playerMovementScript.enabled = true;
            }
            else
            {
                canvasObject.SetActive(true);
                playerMovementScript.enabled = false;
            }
        
    }
}
