using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    new Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    // Player sound variables
    public AudioClip movingSound; // Sound clip to play while moving
    public float soundVolume = 0.5f; // Volume of the sound

    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isMoving; // Tracks if the player is moving

    public bool isMovementEnabled = true; // Flag to control player movement


    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Get the AudioSource component attached to the same game object
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        // Check if the player is moving
        isMoving = targetVelocity != Vector2.zero;

        // Play or stop the sound based on the player's movement
        if (isMoving && movingSound != null)
        {
            // Play the moving sound if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.clip = movingSound;
                audioSource.volume = soundVolume;
                audioSource.Play();
            }
        }
        else
        {
            // Stop the sound if the player is not moving
            audioSource.Stop();
        }
    }
}
