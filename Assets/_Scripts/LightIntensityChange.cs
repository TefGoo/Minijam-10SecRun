using UnityEngine;

public class LightIntensityChange : MonoBehaviour
{
    public Light targetLight;
    public float newIntensity = 0.5f;
    public float returnDuration = 10f;

    private float originalIntensity;
    private bool isChangingIntensity = false;
    private float startIntensity;
    private float targetIntensity;
    private float changeDuration;

    private void Start()
    {
        // Store the original intensity of the light
        originalIntensity = targetLight.intensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isChangingIntensity)
        {
            // Start the coroutine to change the intensity
            StartCoroutine(ChangeIntensity());
        }
    }

    private System.Collections.IEnumerator ChangeIntensity()
    {
        // Set the flag to indicate that the intensity is changing
        isChangingIntensity = true;

        // Change the intensity of the light to the new value immediately
        targetLight.intensity = newIntensity;

        // Wait for a very short duration for the immediate change to take effect
        yield return new WaitForSeconds(0.01f);

        // Store the start and target intensities for interpolation
        startIntensity = newIntensity;
        targetIntensity = originalIntensity;

        // Calculate the duration of the interpolation based on the return duration
        changeDuration = returnDuration;

        // Set the current time to zero
        float currentTime = 0f;

        while (currentTime < changeDuration)
        {
            // Increment the current time
            currentTime += Time.deltaTime;

            // Calculate the interpolation factor
            float t = currentTime / changeDuration;

            // Apply a smoother transition curve to the interpolation factor
            t = Mathf.SmoothStep(0f, 1f, t);

            // Interpolate the intensity value
            float newIntensityValue = Mathf.Lerp(startIntensity, targetIntensity, t);

            // Update the light intensity
            targetLight.intensity = newIntensityValue;

            yield return null;
        }

        // Ensure the final intensity is set to the exact original intensity value
        targetLight.intensity = originalIntensity;

        // Reset the flag to indicate that the intensity has returned to normal
        isChangingIntensity = false;
    }
}
