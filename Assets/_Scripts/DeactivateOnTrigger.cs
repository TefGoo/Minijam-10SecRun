using UnityEngine;

public class DeactivateOnTrigger : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject panelToDectivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToDeactivate.SetActive(false);
            panelToDectivate.SetActive(false);
        }
    }
}
