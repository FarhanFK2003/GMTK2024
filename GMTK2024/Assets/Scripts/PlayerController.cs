using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;             // Speed at which the player will move
    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
    public Transform playerModel;          // Reference to the player model (to rotate)
    public Animator animator;              // Reference to the Animator component
    public GameObject gun;                 // Reference to the gun GameObject
    public GameObject lightSaber;          // Reference to the light saber GameObject
    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active

    private bool canMove = true;           // Flag to check if the player can move
    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated

    void Update()
    {
        // Check if any action animations are playing
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");

        // Set the canMove flag based on the animations
        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing);

        // If the player can move, handle movement and rotation
        if (canMove)
        {
            // Get input from WASD keys
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Create a Vector3 based on the input
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Move the player
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

            // Rotate the player model to face the movement direction
            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
                animator.ResetTrigger("isIdle");      // Reset the idle trigger
            }
            else
            {
                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
                animator.SetTrigger("isIdle");        // Set the idle trigger
            }
        }

        // Check for roll action (can be performed while moving)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isRoll");
        }

        // Check for kick action
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("isKicking");
            canMove = false;
        }

        // Check for interact action
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isInteract");
            canMove = false;
        }

        // Check for punch action
        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
        {
            animator.SetTrigger("isPunch");
            canMove = false;
        }

        // Check for shoot action
        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
        {
            animator.SetTrigger("isShoot");
            canMove = false;
            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
        }

        // Check for slash action
        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
        {
            animator.SetTrigger("isSlash");
            canMove = false;
            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
        }

        // Handle gun delay timer
        if (gunReadyToActivate)
        {
            gunDelayTimer -= Time.deltaTime;
            if (gunDelayTimer <= 0)
            {
                gun.SetActive(true);
                gunTimer = gunActiveDuration; // Reset the gun timer
                gunReadyToActivate = false;   // Reset the flag
            }
        }

        // Handle light saber delay timer
        if (lightSaberReadyToActivate)
        {
            lightSaberDelayTimer -= Time.deltaTime;
            if (lightSaberDelayTimer <= 0)
            {
                lightSaber.SetActive(true);
                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
                lightSaberReadyToActivate = false;   // Reset the flag
            }
        }

        // Handle gun active timer
        if (gunTimer > 0)
        {
            gunTimer -= Time.deltaTime;
            if (gunTimer <= 0)
            {
                gun.SetActive(false);
            }
        }

        // Handle light saber active timer
        if (lightSaberTimer > 0)
        {
            lightSaberTimer -= Time.deltaTime;
            if (lightSaberTimer <= 0)
            {
                lightSaber.SetActive(false);
            }
        }
    }
}
