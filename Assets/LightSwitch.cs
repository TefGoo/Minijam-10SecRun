using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightSource;

    private bool isOn = false;

    private void Start()
    {
        // Turn off the light source by default
        lightSource.enabled = false;
    }

    public void Toggle()
    {
        isOn = !isOn;
        lightSource.enabled = isOn;
    }

}
