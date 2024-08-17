using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;      // Speed at which the player will move
    public Transform playerModel;   // Reference to the player model (to rotate)
    public Animator animator;       // Reference to the Animator component

    // Update is called once per frame
    void Update()
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
            playerModel.rotation = Quaternion.LookRotation(movement);
            animator.SetBool("isRunning", true);  // Set isRunning to true when the player is moving
            animator.ResetTrigger("isIdle");      // Reset the idle trigger
        }
        else
        {
            animator.SetBool("isRunning", false); // Set isRunning to false when the player is not moving
            animator.SetTrigger("isIdle");        // Set the idle trigger
        }

        // Check for roll action
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isRoll");
        }

        // Check for kick action
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("isKicking");
        }

        // Check for interact action
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isInteract");
        }

        // Check for punch action
        if (Input.GetMouseButtonDown(0)) // Left Mouse Button
        {
            animator.SetTrigger("isPunch");
        }
    }
}
