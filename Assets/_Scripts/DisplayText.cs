using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public float delay = 5f; // Delay in seconds before deactivating the canvas

    private void Start()
    {
        // Deactivate the canvas object after the specified delay
        Invoke("DeactivateCanvas", delay);
    }

    private void DeactivateCanvas()
    {
        gameObject.SetActive(false); // Deactivate the canvas object
    }
}
