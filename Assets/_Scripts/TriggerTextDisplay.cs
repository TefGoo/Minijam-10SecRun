using UnityEngine;
using TMPro;
using System.Collections;

public class TriggerTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public float displayTime = 7f;
    private bool isDisplayed = false;

    private void Start()
    {
        tmpText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDisplayed)
        {
            tmpText.enabled = true;
            isDisplayed = true;
            StartCoroutine(HideTextAfterDelay(displayTime));
        }

        // Disable the trigger
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        tmpText.enabled = false;
        isDisplayed = false;
    }
}
