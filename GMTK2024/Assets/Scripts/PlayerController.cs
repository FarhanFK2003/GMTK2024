//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active

//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }
//}

//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
//    public Vector3 particleSpawnPosition; // Vector3 for the particle spawn position
//    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
//    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played

//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
//    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
//            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle particle effect delay timer
//        if (particleEffectReadyToPlay)
//        {
//            particleEffectTimer -= Time.deltaTime;
//            if (particleEffectTimer <= 0)
//            {
//                GameObject particleEffect = Instantiate(lightSaberParticleEffect, transform.position + particleSpawnPosition, Quaternion.identity);
//                Destroy(particleEffect, particleEffectDuration + 2); // Destroy the particle effect after the specified duration
//                particleEffectReadyToPlay = false; // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }
//}


//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
//    public float particleSpawnOffsetY = 1.0f; // Y-axis offset for the particle spawn position
//    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
//    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played

//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
//    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
//            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle particle effect delay timer
//        if (particleEffectReadyToPlay)
//        {
//            particleEffectTimer -= Time.deltaTime;
//            if (particleEffectTimer <= 0)
//            {
//                Vector3 particlePosition = transform.position + new Vector3(0, particleSpawnOffsetY, 0);
//                GameObject particleEffect = Instantiate(lightSaberParticleEffect, particlePosition, Quaternion.identity);
//                Destroy(particleEffect, particleEffectDuration); // Destroy the particle effect after the specified duration
//                particleEffectReadyToPlay = false; // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }
//}

// Updated
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
//    public GameObject bulletPrefab;        // Reference to the bullet prefab
//    public Transform bulletSpawnPoint;     // Reference to the bullet spawn point
//    public float particleSpawnOffsetY = 1.0f; // Y-axis offset for the particle spawn position
//    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
//    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played
//    public float bulletSpeed = 10.0f;      // Speed of the bullet

//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
//    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
//            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//                ShootBullet();                // Call the method to shoot the bullet
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle particle effect delay timer
//        if (particleEffectReadyToPlay)
//        {
//            particleEffectTimer -= Time.deltaTime;
//            if (particleEffectTimer <= 0)
//            {
//                Vector3 particlePosition = transform.position + new Vector3(0, particleSpawnOffsetY, 0);
//                GameObject particleEffect = Instantiate(lightSaberParticleEffect, particlePosition, Quaternion.identity);
//                Destroy(particleEffect, particleEffectDuration); // Destroy the particle effect after the specified duration
//                particleEffectReadyToPlay = false; // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }

//    void ShootBullet()
//    {
//        // Instantiate the bullet prefab
//        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

//        // Get the Rigidbody component
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        if (bulletRb != null)
//        {
//            // Ensure Rigidbody is not kinematic
//            bulletRb.isKinematic = false;

//            // Apply force to the bullet
//            bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
//        }

//        // Destroy the bullet after 1 second
//        Destroy(bullet, 4.0f);
//    }

//}


//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
//    public GameObject bulletPrefab;        // Reference to the bullet prefab
//    public Transform bulletSpawnPoint;     // Reference to the bullet spawn point
//    public float particleSpawnOffsetY = 1.0f; // Y-axis offset for the particle spawn position
//    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
//    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played
//    public float bulletSpeed = 10.0f;      // Speed of the bullet
//    public float maxHealth = 100.0f;       // Maximum health of the player
//    public Slider healthSlider;            // Reference to the health slider in the UI

//    private float currentHealth;           // Current health of the player
//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
//    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

//    void Start()
//    {
//        // Initialize health
//        currentHealth = maxHealth;
//        healthSlider.maxValue = maxHealth;
//        healthSlider.value = currentHealth;
//    }

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
//            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//                ShootBullet();                // Call the method to shoot the bullet
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle particle effect delay timer
//        if (particleEffectReadyToPlay)
//        {
//            particleEffectTimer -= Time.deltaTime;
//            if (particleEffectTimer <= 0)
//            {
//                Vector3 particlePosition = transform.position + new Vector3(0, particleSpawnOffsetY, 0);
//                GameObject particleEffect = Instantiate(lightSaberParticleEffect, particlePosition, Quaternion.identity);
//                Destroy(particleEffect, particleEffectDuration); // Destroy the particle effect after the specified duration
//                particleEffectReadyToPlay = false; // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }

//    void ShootBullet()
//    {
//        // Instantiate the bullet prefab
//        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

//        // Get the Rigidbody component
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        if (bulletRb != null)
//        {
//            // Ensure Rigidbody is not kinematic
//            bulletRb.isKinematic = false;

//            // Apply force to the bullet
//            bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
//        }

//        // Destroy the bullet after 1 second
//        Destroy(bullet, 4.0f);
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Check if the player collided with an enemy
//        if (collision.gameObject.CompareTag("Enemy"))
//        {
//            Debug.Log("Damage");
//            // Reduce health
//            TakeDamage(10.0f); // You can adjust the damage value as needed
//        }
//    }

//    void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth < 0)
//        {
//            currentHealth = 0;
//        }
//        healthSlider.value = currentHealth;

//        // Check if the player is dead
//        if (currentHealth <= 0)
//        {
//            // Handle player death (e.g., trigger death animation, restart the game, etc.)
//            Debug.Log("Player is dead!");
//        }
//    }
//}

// Updated
//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
//    public GameObject bulletPrefab;        // Reference to the bullet prefab
//    public Transform bulletSpawnPoint;     // Reference to the bullet spawn point
//    public float particleSpawnOffsetY = 1.0f; // Y-axis offset for the particle spawn position
//    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
//    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played
//    public float bulletSpeed = 10.0f;      // Speed of the bullet
//    public float maxHealth = 100.0f;       // Maximum health of the player
//    public Slider healthSlider;            // Reference to the health slider in the UI

//    private float currentHealth;           // Current health of the player
//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
//    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

//    void Start()
//    {
//        // Initialize health
//        currentHealth = maxHealth;
//        healthSlider.maxValue = maxHealth;
//        healthSlider.value = currentHealth;
//    }

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");
//        bool isDead = currentState.IsName("CharacterArmature_Death");
//        bool isHurt = currentState.IsName("CharacterArmature_HitReceive_2");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing || isDead);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
//            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//                ShootBullet();                // Call the method to shoot the bullet
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle particle effect delay timer
//        if (particleEffectReadyToPlay)
//        {
//            particleEffectTimer -= Time.deltaTime;
//            if (particleEffectTimer <= 0)
//            {
//                Vector3 particlePosition = transform.position + new Vector3(0, particleSpawnOffsetY, 0);
//                GameObject particleEffect = Instantiate(lightSaberParticleEffect, particlePosition, Quaternion.identity);
//                Destroy(particleEffect, particleEffectDuration); // Destroy the particle effect after the specified duration
//                particleEffectReadyToPlay = false; // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }

//    void ShootBullet()
//    {
//        // Instantiate the bullet prefab
//        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

//        // Get the Rigidbody component
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        if (bulletRb != null)
//        {
//            // Ensure Rigidbody is not kinematic
//            bulletRb.isKinematic = false;

//            // Apply force to the bullet
//            bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
//        }

//        // Destroy the bullet after 1 second
//        Destroy(bullet, 4.0f);
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Check if the player collided with an enemy
//        if (collision.gameObject.CompareTag("Enemy"))
//        {
//            Debug.Log("Damage");

//            // Reduce health
//            TakeDamage(10.0f); // You can adjust the damage value as needed

//            if(currentHealth > 0)
//            {
//                // Trigger hurt animation
//                animator.SetTrigger("isHurt");
//            }

//        }
//    }

//    void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth < 0)
//        {
//            currentHealth = 0;
//        }
//        healthSlider.value = currentHealth;

//        // Check if the player is dead
//        if (currentHealth <= 0)
//        {
//            // Trigger death animation
//            animator.SetTrigger("isDead");

//            // Handle player death (e.g., trigger death animation, restart the game, etc.)
//            Debug.Log("Player is dead!");

//            canMove = false;

//            // Stop the game
//            //StartCoroutine(GameOver());
//        }
//    }

//    IEnumerator GameOver()
//    {
//        // Wait for a short duration to allow the death animation to play
//        yield return new WaitForSeconds(1.0f);

//        // Pause the game
//        Time.timeScale = 0;
//    }
//}


//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5.0f;             // Speed at which the player will move
//    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
//    public Transform playerModel;          // Reference to the player model (to rotate)
//    public Animator animator;              // Reference to the Animator component
//    public GameObject gun;                 // Reference to the gun GameObject
//    public GameObject lightSaber;          // Reference to the light saber GameObject
//    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
//    public GameObject bulletPrefab;        // Reference to the bullet prefab
//    public Transform bulletSpawnPoint;     // Reference to the bullet spawn point
//    public float particleSpawnOffsetY = 1.0f; // Y-axis offset for the particle spawn position
//    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
//    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
//    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
//    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
//    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
//    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played
//    public float bulletSpeed = 10.0f;      // Speed of the bullet
//    public float maxHealth = 100.0f;       // Maximum health of the player
//    public Slider healthSlider;            // Reference to the health slider in the UI

//    // Sound effects
//    public AudioClip shootSound;
//    public AudioClip swordSound;
//    public AudioClip hurtSound;
//    public AudioClip deathSound;
//    public AudioSource audioSource;

//    private float currentHealth;           // Current health of the player
//    private bool canMove = true;           // Flag to check if the player can move
//    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
//    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
//    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
//    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
//    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
//    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
//    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
//    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

//    void Start()
//    {
//        // Initialize health
//        currentHealth = maxHealth;
//        healthSlider.maxValue = maxHealth;
//        healthSlider.value = currentHealth;
//    }

//    void Update()
//    {
//        // Check if any action animations are playing
//        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
//        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
//        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
//        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
//        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
//        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");
//        bool isDead = currentState.IsName("CharacterArmature_Death");
//        bool isHurt = currentState.IsName("CharacterArmature_HitReceive_2");

//        // Set the canMove flag based on the animations
//        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing || isDead);

//        // If the player can move, handle movement and rotation
//        if (canMove)
//        {
//            // Get input from WASD keys
//            float moveHorizontal = Input.GetAxis("Horizontal");
//            float moveVertical = Input.GetAxis("Vertical");

//            // Create a Vector3 based on the input
//            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//            // Move the player
//            transform.Translate(movement * speed * Time.deltaTime, Space.World);

//            // Rotate the player model to face the movement direction
//            if (movement != Vector3.zero)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(movement);
//                playerModel.rotation = Quaternion.Lerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//                animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
//                animator.ResetTrigger("isIdle");      // Reset the idle trigger
//            }
//            else
//            {
//                animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
//                animator.SetTrigger("isIdle");        // Set the idle trigger
//            }
//        }

//        // Check for roll action (can be performed while moving)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            animator.SetTrigger("isRoll");
//        }

//        // Check for kick action
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            animator.SetTrigger("isKicking");
//            canMove = false;
//        }

//        // Check for interact action
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            animator.SetTrigger("isInteract");
//            canMove = false;
//        }

//        // Check for punch action
//        if (Input.GetKeyDown(KeyCode.E)) // Key E for Punch
//        {
//            animator.SetTrigger("isPunch");
//            canMove = false;
//        }

//        // Check for shoot action
//        if (Input.GetMouseButtonDown(0)) // Left Mouse Button for Shoot
//        {
//            animator.SetTrigger("isShoot");
//            canMove = false;
//            gunDelayTimer = gunSpawnDelay; // Reset the delay timer
//            gunReadyToActivate = true;     // Set the flag to indicate the gun should be activated after the delay
//        }

//        // Check for slash action
//        if (Input.GetMouseButtonDown(1)) // Right Mouse Button for Slash
//        {
//            animator.SetTrigger("isSlash");
//            canMove = false;
//            lightSaberDelayTimer = lightSaberSpawnDelay; // Reset the delay timer
//            lightSaberReadyToActivate = true;     // Set the flag to indicate the light saber should be activated after the delay
//            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
//            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay

//            // Play shoot sound effect
//            audioSource.PlayOneShot(swordSound);
//        }

//        // Handle gun delay timer
//        if (gunReadyToActivate)
//        {
//            gunDelayTimer -= Time.deltaTime;
//            if (gunDelayTimer <= 0)
//            {
//                gun.SetActive(true);
//                gunTimer = gunActiveDuration; // Reset the gun timer
//                gunReadyToActivate = false;   // Reset the flag
//                ShootBullet();                // Call the method to shoot the bullet
//            }
//        }

//        // Handle light saber delay timer
//        if (lightSaberReadyToActivate)
//        {
//            lightSaberDelayTimer -= Time.deltaTime;
//            if (lightSaberDelayTimer <= 0)
//            {
//                lightSaber.SetActive(true);
//                lightSaberTimer = lightSaberActiveDuration; // Reset the light saber timer
//                lightSaberReadyToActivate = false;   // Reset the flag
//            }
//        }

//        // Handle particle effect delay timer
//        if (particleEffectReadyToPlay)
//        {
//            particleEffectTimer -= Time.deltaTime;
//            if (particleEffectTimer <= 0)
//            {
//                Vector3 particlePosition = transform.position + new Vector3(0, particleSpawnOffsetY, 0);
//                GameObject particleEffect = Instantiate(lightSaberParticleEffect, particlePosition, Quaternion.identity);
//                Destroy(particleEffect, particleEffectDuration); // Destroy the particle effect after the specified duration
//                particleEffectReadyToPlay = false; // Reset the flag
//            }
//        }

//        // Handle gun active timer
//        if (gunTimer > 0)
//        {
//            gunTimer -= Time.deltaTime;
//            if (gunTimer <= 0)
//            {
//                gun.SetActive(false);
//            }
//        }

//        // Handle light saber active timer
//        if (lightSaberTimer > 0)
//        {
//            lightSaberTimer -= Time.deltaTime;
//            if (lightSaberTimer <= 0)
//            {
//                lightSaber.SetActive(false);
//            }
//        }
//    }

//    void ShootBullet()
//    {
//        // Instantiate the bullet prefab
//        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

//        // Get the Rigidbody component
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        if (bulletRb != null)
//        {
//            // Ensure Rigidbody is not kinematic
//            bulletRb.isKinematic = false;

//            // Apply force to the bullet
//            bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
//        }

//        // Play shoot sound effect
//        audioSource.PlayOneShot(shootSound);

//        // Destroy the bullet after 4 seconds
//        Destroy(bullet, 4.0f);
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Check if the player collided with an enemy
//        if (collision.gameObject.CompareTag("Enemy"))
//        {
//            Debug.Log("Damage");

//            // Reduce health
//            TakeDamage(10.0f); // You can adjust the damage value as needed

//            if (currentHealth > 0)
//            {
//                // Trigger hurt animation
//                animator.SetTrigger("isHurt");

//                // Play hurt sound effect
//                audioSource.PlayOneShot(hurtSound);
//            }

//        }
//    }

//    void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth < 0)
//        {
//            currentHealth = 0;
//        }
//        healthSlider.value = currentHealth;

//        // Check if the player is dead
//        if (currentHealth <= 0)
//        {
//            // Trigger death animation
//            animator.SetTrigger("isDead");

//            // Play death sound effect
//            audioSource.PlayOneShot(deathSound);

//            // Handle player death (e.g., trigger death animation, restart the game, etc.)
//            Debug.Log("Player is dead!");

//            canMove = false;

//            // Stop the game
//            //StartCoroutine(GameOver());
//        }
//    }

//    IEnumerator GameOver()
//    {
//        // Wait for a short duration to allow the death animation to play
//        yield return new WaitForSeconds(1.0f);

//        // Pause the game
//        Time.timeScale = 0;
//    }
//}


using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;             // Speed at which the player will move
    public float rotationSpeed = 5.0f;     // Speed at which the player will rotate
    public Transform playerModel;          // Reference to the player model (to rotate)
    public Animator animator;              // Reference to the Animator component
    public GameObject gun;                 // Reference to the gun GameObject
    public GameObject lightSaber;          // Reference to the light saber GameObject
    public GameObject lightSaberParticleEffect; // Reference to the light saber particle effect
    public GameObject bulletPrefab;        // Reference to the bullet prefab
    public Transform bulletSpawnPoint;     // Reference to the bullet spawn point
    public Transform slashSpawnPoint;      // Reference to the slash spawn point
    public float particleSpawnOffsetY = 1.0f; // Y-axis offset for the particle spawn position
    public float particleEffectDuration = 2.0f; // Duration before the particle effect is destroyed
    public float gunActiveDuration = 1.0f; // Duration for which the gun remains active
    public float lightSaberActiveDuration = 1.0f; // Duration for which the light saber remains active
    public float gunSpawnDelay = 0.5f;     // Delay before the gun becomes active
    public float lightSaberSpawnDelay = 0.5f; // Delay before the light saber becomes active
    public float particleEffectDelay = 0.0f; // Delay before the particle effect is played
    public float bulletSpeed = 10.0f;      // Speed of the bullet
    public float maxHealth = 100.0f;       // Maximum health of the player
    public Slider healthSlider;            // Reference to the health slider in the UI
    public AudioClip bombSound;             // Bomb sound effect
    public GameObject bombExplosionEffect;  // Particle effect prefab for bomb explosion
    public AudioClip healthPickupSound;
    public float healthPickupAmount = 10.0f;

    // Sound effects
    public AudioClip shootSound;
    public AudioClip swordSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioSource audioSource;

    private float currentHealth;           // Current health of the player
    private bool canMove = true;           // Flag to check if the player can move
    private float gunTimer = 0.0f;         // Timer to track the gun's active duration
    private float lightSaberTimer = 0.0f;  // Timer to track the light saber's active duration
    private float gunDelayTimer = 0.0f;    // Timer to track the delay before the gun is activated
    private float lightSaberDelayTimer = 0.0f; // Timer to track the delay before the light saber is activated
    private float particleEffectTimer = 0.0f; // Timer to track the delay before the particle effect is played
    private bool gunReadyToActivate = false; // Flag to check if the gun is ready to be activated
    private bool lightSaberReadyToActivate = false; // Flag to check if the light saber is ready to be activated
    private bool particleEffectReadyToPlay = false; // Flag to check if the particle effect is ready to be played

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        // Check if any action animations are playing
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        bool isKicking = currentState.IsName("CharacterArmature_Kick_Left");
        bool isInteracting = currentState.IsName("CharacterArmature_Interact");
        bool isPunching = currentState.IsName("CharacterArmature_Punch_Left");
        bool isShooting = currentState.IsName("CharacterArmature_Gun_Shoot");
        bool isSlashing = currentState.IsName("CharacterArmature_Sword_Slash");
        bool isDead = currentState.IsName("CharacterArmature_Death");
        bool isHurt = currentState.IsName("CharacterArmature_HitReceive_2");

        // Set the canMove flag based on the animations
        canMove = !(isKicking || isInteracting || isPunching || isShooting || isSlashing || isDead);

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
            particleEffectTimer = particleEffectDelay; // Reset the particle effect timer
            particleEffectReadyToPlay = true; // Set the flag to indicate the particle effect should be played after the delay

            // Play sword sound effect
            audioSource.PlayOneShot(swordSound);
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
                ShootBullet();                // Call the method to shoot the bullet
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

        // Handle particle effect delay timer
        if (particleEffectReadyToPlay)
        {
            particleEffectTimer -= Time.deltaTime;
            if (particleEffectTimer <= 0)
            {
                Vector3 particlePosition = slashSpawnPoint.position;
                GameObject particleEffect = Instantiate(lightSaberParticleEffect, particlePosition, Quaternion.identity);
                Destroy(particleEffect, particleEffectDuration); // Destroy the particle effect after the specified duration
                particleEffectReadyToPlay = false; // Reset the flag
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


    void ShootBullet()
    {
        // Instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the Rigidbody component
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // Ensure Rigidbody is not kinematic
            bulletRb.isKinematic = false;

            // Apply force to the bullet
            bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.VelocityChange);
        }

        // Play shoot sound effect
        audioSource.PlayOneShot(shootSound);

        // Destroy the bullet after 4 seconds
        Destroy(bullet, 4.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with an enemy
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Damage");

            // Reduce health
            TakeDamage(10.0f); // You can adjust the damage value as needed

            if (currentHealth > 0)
            {
                // Trigger hurt animation
                animator.SetTrigger("isHurt");

                // Play hurt sound effect
                audioSource.PlayOneShot(hurtSound);
            }

        }

        // Check if the player collided with a bomb
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Debug.Log("Bomb");

            // Reduce health
            TakeDamage(20.0f); // You can adjust the damage value as needed

            if (currentHealth > 0)
            {
                // Trigger hurt animation
                animator.SetTrigger("isHurt");

                // Play hurt sound effect
                audioSource.PlayOneShot(hurtSound);
            }

            // Instantiate bomb explosion effect at the bomb's position
            if (bombExplosionEffect != null)
            {
                Instantiate(bombExplosionEffect, collision.transform.position, Quaternion.identity);
            }

            // Play bomb sound effect at the bomb's position
            if (bombSound != null)
            {
                audioSource.PlayOneShot(bombSound);
            }

            // Optionally destroy the bomb game object
            Destroy(collision.gameObject);
        }

        // Handle collision with health bar
        if (collision.gameObject.CompareTag("Health"))
        {
            // Increase player's health
            currentHealth += healthPickupAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            // Update the health slider
            healthSlider.value = currentHealth;

            // Play health pickup sound effect
            audioSource.PlayOneShot(healthPickupSound);

            // Destroy the health bar GameObject
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            // Trigger death animation
            animator.SetTrigger("isDead");

            // Play death sound effect
            audioSource.PlayOneShot(deathSound);

            // Handle player death (e.g., trigger death animation, restart the game, etc.)
            Debug.Log("Player is dead!");

            canMove = false;

            // Stop the game
            //StartCoroutine(GameOver());
        }
    }
}
