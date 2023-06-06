using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTextOnce : MonoBehaviour
{
    public float displayTime = 4f;

    private TMP_Text textComponent;
    private bool hasDisplayed = false;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.enabled = false; // Hide the text at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasDisplayed)
        {
            hasDisplayed = true;
            textComponent.enabled = true; // Display the text when triggered
            Invoke("HideText", displayTime);
        }
    }

    private void HideText()
    {
        textComponent.enabled = false;
        Destroy(gameObject);
    }
}
