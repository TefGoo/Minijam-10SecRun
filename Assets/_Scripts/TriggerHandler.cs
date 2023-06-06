using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerHandler : MonoBehaviour
{
    public TMP_Text text;
    public float displayTime = 4f;

    private bool hasDisplayed = false;

    private void Start()
    {
        // Hide the text at the start
        text.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasDisplayed)
        {
            hasDisplayed = true;
            text.enabled = true; // Display the text when triggered
            Invoke("HideText", displayTime);
        }
    }

    private void HideText()
    {
        text.enabled = false;
        Destroy(gameObject);
    }
}
