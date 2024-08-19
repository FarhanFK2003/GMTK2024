using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the speed of the movement
    public float range = 2.0f; // The distance the punch moves in the x direction
    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f); // Adjust the offset vector

    void Update()
    {
        // Calculate the horizontal movement using the PingPong function
        float movement = Mathf.PingPong(Time.time * moveSpeed, range);

        // Set the new position of the transform with the offset
        transform.position = new Vector3(movement + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);
    }
}