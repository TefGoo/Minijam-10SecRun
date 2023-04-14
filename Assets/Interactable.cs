using UnityEngine;

public class Interactable : MonoBehaviour
{
    public LightSwitch lightSwitch; // Reference to the LightSwitch script attached to the light

    public void Interact()
    {
        // Toggle the light when interacting with the NPC
        lightSwitch.Toggle();
    }
}
