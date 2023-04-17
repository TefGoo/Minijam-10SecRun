using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderText : MonoBehaviour
{
    public TMP_Text displayText;

    public void Start()
    {
        displayText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(false);
        }
    }
}
