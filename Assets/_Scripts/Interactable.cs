using UnityEngine;

public class Interactable : MonoBehaviour
{
    public LightSwitch lightSwitch; // Reference to the LightSwitch script attached to the light
    public LightSwitch lightSwitch1;
    public LightSwitch lightSwitch2;
    public LightSwitch lightSwitch3;
    public LightSwitch lightSwitch4;
    public LightSwitch lightSwitch5;
    public LightSwitch lightSwitch6;
    public AudioClip interactSound;

    public void Interact()
    {
        // Toggle the light when interacting with the NPC
        lightSwitch.Toggle();
        lightSwitch1.Toggle();
        lightSwitch2.Toggle();
        lightSwitch3.Toggle();
        lightSwitch4.Toggle();
        lightSwitch5.Toggle();
        lightSwitch6.Toggle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(interactSound, transform.position);
        }
    }
}
