using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightSource;

    private bool isOn = true;

    private static LightSwitch[] switches;

    private void Start()
    {
        // Turn on the light source by default
        lightSource.enabled = true;

        // Find all the LightSwitch objects in the scene
        switches = FindObjectsOfType<LightSwitch>();
    }

    public void Toggle()
    {
        isOn = !isOn;
        lightSource.enabled = isOn;
    }

    public void TurnOn()
    {
        isOn = true;
        lightSource.enabled = true;
    }

    public static void TurnOnAllSwitches()
    {
        foreach (LightSwitch lightSwitch in switches)
        {
            lightSwitch.TurnOn();
        }
    }
}
