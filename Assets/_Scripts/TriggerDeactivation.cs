using UnityEngine;

public class TriggerDeactivation : MonoBehaviour
{
    public GameObject triggerToDestroy;
    public GameObject triggerToDeactivateDelayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the immediate trigger immediately
            Destroy(triggerToDestroy);

            // Call the DeactivateDelayedTrigger method after 3 seconds
            Invoke("DeactivateDelayedTrigger", 3f);
        }
    }

    private void DeactivateDelayedTrigger()
    {
        // Deactivate the delayed trigger after 3 seconds
        triggerToDeactivateDelayed.SetActive(false);
    }
}
