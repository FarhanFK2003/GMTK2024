using UnityEngine;

public class LockRotation : MonoBehaviour
{
    public bool lockX = false; // Toggle for locking the X axis
    public bool lockY = false; // Toggle for locking the Y axis
    public bool lockZ = false; // Toggle for locking the Z axis

    public float XValue = 0.0f; // The fixed X rotation value
    public float YValue = 0.0f; // The fixed Y rotation value
    public float ZValue = 0.0f; // The fixed Z rotation value

    private Quaternion initialRotation;

    void Start()
    {
        // Save the initial rotation of the GameObject
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Lock the specified axes
        if (lockX)
        {
            currentRotation.x = XValue;
        }
        if (lockY)
        {
            currentRotation.y = YValue;
        }
        if (lockZ)
        {
            currentRotation.z = ZValue;
        }

        // Apply the new rotation
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
