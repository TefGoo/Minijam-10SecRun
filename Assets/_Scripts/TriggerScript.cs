using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject gameObjectToActivate;
    public GameObject gameTriggerToActivate;

    private void Start()
    {
        gameObjectToActivate.SetActive(false);
        gameTriggerToActivate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObjectToActivate.SetActive(true);
            gameTriggerToActivate.SetActive(true);
            Debug.Log("Trigger activated");
        }
    }
}
