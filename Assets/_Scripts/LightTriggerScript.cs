using System.Collections;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour
{
    public Light lightToActivate;
    public AudioClip soundToPlay;

    private bool hasPlayedSound = false;

    private void Start()
    {
        lightToActivate.enabled = false;
        hasPlayedSound = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasPlayedSound)
            {
                AudioSource.PlayClipAtPoint(soundToPlay, transform.position);
                hasPlayedSound = true;
            }

            StartCoroutine(TurnLightOnAndOff());
        }
        // Disable the trigger
        GetComponent<Collider>().enabled = false;
    }

    private IEnumerator TurnLightOnAndOff()
    {
        lightToActivate.enabled = true;
        yield return new WaitForSeconds(0.5f);
        lightToActivate.enabled = false;
        yield return new WaitForSeconds(0.2f);
        lightToActivate.enabled = true;
        yield return new WaitForSeconds(0.3f);
        lightToActivate.enabled = false;
    }
}
