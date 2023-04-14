using UnityEngine;

public class Interactable : MonoBehaviour
{
    public LightSwitch lightSwitch; // Reference to the LightSwitch script attached to the light
    public LightSwitch lightSwitch1;
    public LightSwitch lightSwitch2;

    public void Interact()
    {
        // Toggle the light when interacting with the NPC
        lightSwitch.Toggle();
        lightSwitch1.Toggle();
        lightSwitch2.Toggle();
    }
}
