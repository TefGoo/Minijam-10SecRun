using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public AudioClip switchOnSound;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            LightSwitch.TurnOnAllSwitches();
            AudioSource.PlayClipAtPoint(switchOnSound, transform.position);
            hasTriggered = true;
        }
    }
}
