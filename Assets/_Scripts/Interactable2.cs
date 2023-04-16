using UnityEngine;

public class Interactable2 : MonoBehaviour
{
    public LightSwitch lightSwitch; // Reference to the LightSwitch script attached to the light
    public LightSwitch lightSwitch1;
    public LightSwitch lightSwitch2;
    public LightSwitch lightSwitch3;
    public LightSwitch lightSwitch4;
    public LightSwitch lightSwitch5;
    public LightSwitch lightSwitch6;
    public AudioClip interactSound;
    public GameObject objectToActivate;

    private void Start()
    {
        objectToActivate.SetActive(false);
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(interactSound, transform.position);
            // Toggle the light when interacting with the NPC
            lightSwitch.Toggle();
            lightSwitch1.Toggle();
            lightSwitch2.Toggle();
            lightSwitch3.Toggle();
            lightSwitch4.Toggle();
            lightSwitch5.Toggle();
            lightSwitch6.Toggle();

            // Activate the object
            objectToActivate.SetActive(true);

            // Disable the trigger
            GetComponent<Collider>().enabled = false;
        }
    }
}
