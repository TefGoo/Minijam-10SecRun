using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightSource;

    private bool isOn = true;

    private void Start()
    {
        // Turn on the light source by default
        lightSource.enabled = true;
    }

    public void Toggle()
    {
        isOn = !isOn;
        lightSource.enabled = isOn;
    }
}
