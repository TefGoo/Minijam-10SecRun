using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public Collider triggerToActivate;

    private void Start()
    {
        // Deactivate the trigger collider at the start
        triggerToActivate.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Activate the trigger collider when the player enters this trigger
        if (other.CompareTag("Player"))
        {
            triggerToActivate.enabled = true;
        }
    }
}
