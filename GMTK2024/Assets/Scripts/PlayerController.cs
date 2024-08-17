using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed at which the player will move
    public float speed = 5.0f;

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
    }
}
