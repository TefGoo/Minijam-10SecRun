using UnityEngine;
using UnityEngine.EventSystems;

public class FinalInteract : MonoBehaviour
{
    public AudioClip interactSound;
    public GameObject canvasObject; // Reference to the canvas object to be displayed
    public GameObject panelToDelay; // Reference to the panel that should have a delay
    public float delay = 3f; // Delay time in seconds

    public FirstPersonMovement playerMovement; // Reference to the player movement script/component

    private bool isCanvasDisplayed = false; // Flag to keep track of whether the canvas is displayed or not
    private bool isInteracting = false; // Flag to determine if the player is currently interacting with the canvas

    private void Start()
    {
        canvasObject.SetActive(false);
        panelToDelay.SetActive(false);
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
                isInteracting = true; // Set the flag to true to allow interaction with the canvas
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor to allow interaction
                Cursor.visible = true; // Show the cursor

                StartCoroutine(ShowDelayedPanel());
            }
        }
    }

    private System.Collections.IEnumerator ShowDelayedPanel()
    {
        yield return new WaitForSeconds(delay);

        panelToDelay.SetActive(true);
    }

    private void Update()
    {
        if (isInteracting)
        {
            // Check if the left mouse button is pressed to simulate button clicks
            if (Input.GetMouseButtonDown(0))
            {
                // Convert the mouse position to UI space
                Vector2 mousePosition = Input.mousePosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasObject.transform as RectTransform, mousePosition, null, out Vector2 localPoint);

                // Create a pointer event and set its position to the local point within the UI
                PointerEventData pointerEventData = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
                pointerEventData.position = localPoint;

                // Raycast to find the UI element under the mouse
                System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> results = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>();
                UnityEngine.EventSystems.EventSystem.current.RaycastAll(pointerEventData, results);

                // Trigger the UI button click if a button is found
                foreach (UnityEngine.EventSystems.RaycastResult result in results)
                {
                    UnityEngine.UI.Button button = result.gameObject.GetComponent<UnityEngine.UI.Button>();
                    if (button != null)
                    {
                        button.onClick.Invoke();
                        break;
                    }
                }
            }
        }
    }
}
