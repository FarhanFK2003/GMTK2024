//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyFollow : MonoBehaviour
//{
//    public Transform player;            // Reference to the player's transform
//    public float stoppingDistance = 2.0f; // Distance at which the enemy stops following the player
//    private NavMeshAgent navMeshAgent;  // Reference to the NavMeshAgent component

//    void Start()
//    {
//        // Get the NavMeshAgent component attached to this GameObject
//        navMeshAgent = GetComponent<NavMeshAgent>();

//        if (navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent component is missing from this GameObject.");
//        }
//    }

//    void Update()
//    {
//        if (player == null)
//        {
//            Debug.LogWarning("Player reference is missing. Please assign the player in the Inspector.");
//            return;
//        }

//        // Calculate the distance to the player
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//        // If the distance to the player is less than stopping distance, stop moving
//        if (distanceToPlayer < stoppingDistance)
//        {
//            navMeshAgent.isStopped = true;
//        }
//        else
//        {
//            navMeshAgent.isStopped = false;
//            navMeshAgent.SetDestination(player.position);
//        }
//    }
//}

// Updated
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyFollow : MonoBehaviour
//{
//    public Transform player;                // Reference to the player's transform
//    public float stoppingDistance = 2.0f;   // Distance at which the enemy stops following the player
//    public float detectionRadius = 5.0f;    // Radius within which the enemy detects the player
//    public Animator animator;               // Reference to the Animator component

//    private NavMeshAgent navMeshAgent;      // Reference to the NavMeshAgent component
//    private bool isPlayerInRange = false;   // Flag to check if the player is within detection range

//    void Start()
//    {
//        // Get the NavMeshAgent component attached to this GameObject
//        navMeshAgent = GetComponent<NavMeshAgent>();

//        if (navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent component is missing from this GameObject.");
//        }

//        // Ensure the enemy has an Animator component
//        if (animator == null)
//        {
//            animator = GetComponent<Animator>();

//            if (animator == null)
//            {
//                Debug.LogError("Animator component is missing from this GameObject.");
//            }
//        }

//        // Set up the trigger collider for detection
//        SphereCollider detectionCollider = gameObject.AddComponent<SphereCollider>();
//        detectionCollider.isTrigger = true;
//        detectionCollider.radius = detectionRadius;
//    }

//    void Update()
//    {
//        if (player == null)
//        {
//            Debug.LogWarning("Player reference is missing. Please assign the player in the Inspector.");
//            return;
//        }

//        if (isPlayerInRange)
//        {
//            // Calculate the distance to the player
//            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//            // If the distance to the player is less than stopping distance, stop moving
//            if (distanceToPlayer < stoppingDistance)
//            {
//                navMeshAgent.isStopped = true;
//                animator.SetBool("isWalking", false);
//            }
//            else
//            {
//                navMeshAgent.isStopped = false;
//                navMeshAgent.SetDestination(player.position);
//                animator.SetBool("isWalking", true);
//            }
//        }
//        else
//        {
//            navMeshAgent.isStopped = true;
//            animator.SetBool("isWalking", false);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        // Check if the player entered the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = true;
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        // Check if the player exited the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = false;
//        }
//    }
//}


//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyFollow : MonoBehaviour
//{
//    public Transform player;                // Reference to the player's transform
//    public float stoppingDistance = 2.0f;   // Distance at which the enemy stops following the player
//    public float detectionRadius = 5.0f;    // Radius within which the enemy detects the player
//    public Animator animator;               // Reference to the Animator component
//    public float maxHealth = 100.0f;        // Maximum health of the enemy
//    public float currentHealth;             // Current health of the enemy

//    private NavMeshAgent navMeshAgent;      // Reference to the NavMeshAgent component
//    private bool isPlayerInRange = false;   // Flag to check if the player is within detection range

//    void Start()
//    {
//        // Get the NavMeshAgent component attached to this GameObject
//        navMeshAgent = GetComponent<NavMeshAgent>();

//        if (navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent component is missing from this GameObject.");
//        }

//        // Ensure the enemy has an Animator component
//        if (animator == null)
//        {
//            animator = GetComponent<Animator>();

//            if (animator == null)
//            {
//                Debug.LogError("Animator component is missing from this GameObject.");
//            }
//        }

//        // Set up the trigger collider for detection
//        SphereCollider detectionCollider = gameObject.AddComponent<SphereCollider>();
//        detectionCollider.isTrigger = true;
//        detectionCollider.radius = detectionRadius;

//        // Initialize health
//        currentHealth = maxHealth;
//    }

//    void Update()
//    {
//        if (player == null)
//        {
//            Debug.LogWarning("Player reference is missing. Please assign the player in the Inspector.");
//            return;
//        }

//        if (isPlayerInRange)
//        {
//            // Calculate the distance to the player
//            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//            // If the distance to the player is less than stopping distance, stop moving
//            if (distanceToPlayer < stoppingDistance)
//            {
//                navMeshAgent.isStopped = true;
//                animator.SetBool("isWalking", false);
//            }
//            else
//            {
//                navMeshAgent.isStopped = false;
//                navMeshAgent.SetDestination(player.position);
//                animator.SetBool("isWalking", true);
//            }
//        }
//        else
//        {
//            navMeshAgent.isStopped = true;
//            animator.SetBool("isWalking", false);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        // Check if the player entered the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = true;
//        }

//        // Check if the enemy collided with a bullet or slash
//        if (other.CompareTag("Bullet") || other.CompareTag("Slash"))
//        {
//            TakeDamage(10.0f); // Adjust the damage value as needed
//            //Destroy(other.gameObject); // Destroy the bullet or slash prefab
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        // Check if the player exited the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = false;
//        }
//    }

//    void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        // Play death animation
//        animator.SetTrigger("isDead");

//        // Optionally: Add a delay to allow the death animation to play before destroying the enemy
//        Destroy(gameObject, 2.0f); // Adjust the delay as needed
//    }
//}

// Updated
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyFollow : MonoBehaviour
//{
//    public Transform player;                // Reference to the player's transform
//    public float stoppingDistance = 2.0f;   // Distance at which the enemy stops following the player
//    public float detectionRadius = 5.0f;    // Radius within which the enemy detects the player
//    public Animator animator;               // Reference to the Animator component
//    public float maxHealth = 100.0f;        // Maximum health of the enemy
//    public float currentHealth;             // Current health of the enemy

//    private NavMeshAgent navMeshAgent;      // Reference to the NavMeshAgent component
//    private bool isPlayerInRange = false;   // Flag to check if the player is within detection range

//    void Start()
//    {
//        // Get the NavMeshAgent component attached to this GameObject
//        navMeshAgent = GetComponent<NavMeshAgent>();

//        if (navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent component is missing from this GameObject.");
//        }

//        // Ensure the enemy has an Animator component
//        if (animator == null)
//        {
//            animator = GetComponent<Animator>();

//            if (animator == null)
//            {
//                Debug.LogError("Animator component is missing from this GameObject.");
//            }
//        }

//        // Initialize health
//        currentHealth = maxHealth;

//        // Ensure the enemy has a collider component
//        if (GetComponent<Collider>() == null)
//        {
//            Debug.LogError("Collider component is missing from this GameObject.");
//        }

//        // Set up the trigger collider for detection
//        SphereCollider detectionCollider = gameObject.AddComponent<SphereCollider>();
//        detectionCollider.isTrigger = true;
//        detectionCollider.radius = detectionRadius;
//    }

//    void Update()
//    {
//        if (player == null)
//        {
//            Debug.LogWarning("Player reference is missing. Please assign the player in the Inspector.");
//            return;
//        }

//        if (isPlayerInRange)
//        {
//            // Calculate the distance to the player
//            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//            // If the distance to the player is less than stopping distance, stop moving
//            if (distanceToPlayer < stoppingDistance)
//            {
//                navMeshAgent.isStopped = true;
//                animator.SetBool("isWalking", false);
//            }
//            else
//            {
//                navMeshAgent.isStopped = false;
//                navMeshAgent.SetDestination(player.position);
//                animator.SetBool("isWalking", true);
//            }
//        }
//        else
//        {
//            navMeshAgent.isStopped = true;
//            animator.SetBool("isWalking", false);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        // Check if the player entered the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = true;
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        // Check if the player exited the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = false;
//        }
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Check if the enemy collided with a bullet or slash
//        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Slash"))
//        {
//            TakeDamage(25.0f); // Adjust the damage value as needed
//            //Destroy(collision.gameObject); // Destroy the bullet or slash prefab
//        }
//    }

//    void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if(currentHealth > 0)
//        {
//            // Trigger hurt animation
//            animator.SetTrigger("isHurt");
//        }

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        // Play death animation
//        animator.SetTrigger("isDead");

//        // Optionally: Add a delay to allow the death animation to play before destroying the enemy
//        Destroy(gameObject, 1.2f); // Adjust the delay as needed
//    }
//}

// Updated
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyFollow : MonoBehaviour
//{
//    public Transform player;                // Reference to the player's transform
//    public float stoppingDistance = 2.0f;   // Distance at which the enemy stops following the player
//    public float detectionRadius = 5.0f;    // Radius within which the enemy detects the player
//    public Animator animator;               // Reference to the Animator component
//    public float maxHealth = 100.0f;        // Maximum health of the enemy
//    public float currentHealth;             // Current health of the enemy
//    public AudioClip deathSound;            // Death sound effect
//    private AudioSource audioSource;        // Reference to the AudioSource component

//    private NavMeshAgent navMeshAgent;      // Reference to the NavMeshAgent component
//    private bool isPlayerInRange = false;   // Flag to check if the player is within detection range

//    void Start()
//    {
//        // Get the NavMeshAgent component attached to this GameObject
//        navMeshAgent = GetComponent<NavMeshAgent>();

//        if (navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent component is missing from this GameObject.");
//        }

//        // Ensure the enemy has an Animator component
//        if (animator == null)
//        {
//            animator = GetComponent<Animator>();

//            if (animator == null)
//            {
//                Debug.LogError("Animator component is missing from this GameObject.");
//            }
//        }

//        // Initialize health
//        currentHealth = maxHealth;

//        // Ensure the enemy has a collider component
//        if (GetComponent<Collider>() == null)
//        {
//            Debug.LogError("Collider component is missing from this GameObject.");
//        }

//        // Set up the trigger collider for detection
//        SphereCollider detectionCollider = gameObject.AddComponent<SphereCollider>();
//        detectionCollider.isTrigger = true;
//        detectionCollider.radius = detectionRadius;

//        // Get or add an AudioSource component
//        audioSource = GetComponent<AudioSource>();
//        if (audioSource == null)
//        {
//            audioSource = gameObject.AddComponent<AudioSource>();
//        }
//    }

//    void Update()
//    {
//        if (player == null)
//        {
//            Debug.LogWarning("Player reference is missing. Please assign the player in the Inspector.");
//            return;
//        }

//        if (isPlayerInRange)
//        {
//            // Calculate the distance to the player
//            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//            // If the distance to the player is less than stopping distance, stop moving
//            if (distanceToPlayer < stoppingDistance)
//            {
//                navMeshAgent.isStopped = true;
//                animator.SetBool("isWalking", false);
//            }
//            else
//            {
//                navMeshAgent.isStopped = false;
//                navMeshAgent.SetDestination(player.position);
//                animator.SetBool("isWalking", true);
//            }
//        }
//        else
//        {
//            navMeshAgent.isStopped = true;
//            animator.SetBool("isWalking", false);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        // Check if the player entered the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = true;
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        // Check if the player exited the detection zone
//        if (other.transform == player)
//        {
//            isPlayerInRange = false;
//        }
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        // Check if the enemy collided with a bullet or slash
//        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Slash"))
//        {
//            TakeDamage(25.0f); // Adjust the damage value as needed
//            // Destroy the bullet or slash prefab
//            Destroy(collision.gameObject);
//        }
//    }

//    void TakeDamage(float damage)
//    {
//        currentHealth -= damage;
//        if (currentHealth > 0)
//        {
//            // Trigger hurt animation
//            animator.SetTrigger("isHurt");
//        }

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        // Play death sound
//        if (deathSound != null && audioSource != null)
//        {
//            audioSource.PlayOneShot(deathSound);
//        }

//        // Play death animation
//        animator.SetTrigger("isDead");

//        // Optionally: Add a delay to allow the death animation to play before destroying the enemy
//        Destroy(gameObject, 1.2f); // Adjust the delay as needed
//    }
//}


using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;                // Reference to the player's transform
    public float stoppingDistance = 2.0f;   // Distance at which the enemy stops following the player
    public float detectionRadius = 5.0f;    // Radius within which the enemy detects the player
    public Animator animator;               // Reference to the Animator component
    public float maxHealth = 100.0f;        // Maximum health of the enemy
    public float currentHealth;             // Current health of the enemy
    public AudioClip deathSound;            // Death sound effect
    private AudioSource audioSource;        // Reference to the AudioSource component

    private NavMeshAgent navMeshAgent;      // Reference to the NavMeshAgent component
    private bool isPlayerInRange = false;   // Flag to check if the player is within detection range

    void Start()
    {
        // Get the NavMeshAgent component attached to this GameObject
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing from this GameObject.");
        }

        // Ensure the enemy has an Animator component
        if (animator == null)
        {
            animator = GetComponent<Animator>();

            if (animator == null)
            {
                Debug.LogError("Animator component is missing from this GameObject.");
            }
        }

        // Initialize health
        currentHealth = maxHealth;

        // Ensure the enemy has a collider component
        if (GetComponent<Collider>() == null)
        {
            Debug.LogError("Collider component is missing from this GameObject.");
        }

        // Set up the trigger collider for detection
        SphereCollider detectionCollider = gameObject.AddComponent<SphereCollider>();
        detectionCollider.isTrigger = true;
        detectionCollider.radius = detectionRadius;

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing. Please assign the player in the Inspector.");
            return;
        }

        if (isPlayerInRange)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If the distance to the player is less than stopping distance, stop moving
            if (distanceToPlayer < stoppingDistance)
            {
                navMeshAgent.isStopped = true;
                animator.SetBool("isWalking", false);
            }
            else
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(player.position);
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isWalking", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the detection zone
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exited the detection zone
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collided with a bullet or slash
        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Slash"))
        {
            TakeDamage(25.0f); // Adjust the damage value as needed
            // Destroy the bullet or slash prefab
            Destroy(collision.gameObject);
        }

    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            // Trigger hurt animation
            animator.SetTrigger("isHurt");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death sound
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Play death animation
        animator.SetTrigger("isDead");

        // Optionally: Add a delay to allow the death animation to play before destroying the enemy
        Destroy(gameObject, 1.2f); // Adjust the delay as needed
    }
}
