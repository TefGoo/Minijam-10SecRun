using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 2f; // Interaction range
    public LayerMask interactableLayer; // Layers to check for interactable objects

    private GameObject lastInteractable; // Last interactable object the player was close to

    void Update()
    {
        // Check if player presses the Interact button (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check for interactable objects in range
            Collider[] interactables = Physics.OverlapSphere(transform.position, interactRange, interactableLayer);

            // Cycle through all colliders
            foreach (Collider col in interactables)
            {
                // Check if collider has an interactable component
                Interactable interactable = col.GetComponent<Interactable>();

                if (interactable != null)
                {
                    // Interact with the object
                    interactable.Interact();
                    lastInteractable = col.gameObject;
                    break;
                }
            }
        }
    }

    // Gizmos for interaction range sphere
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
