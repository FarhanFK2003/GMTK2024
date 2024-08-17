using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotateSpeed = 100f;

    void Update()
    {
        // Rotate around the y-axis
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}