using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject[] lights;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Turn on all the lights
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }
}
