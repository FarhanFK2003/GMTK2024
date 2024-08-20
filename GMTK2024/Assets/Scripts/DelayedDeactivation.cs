using System.Collections;
using UnityEngine;

public class DelayedDeactivation : MonoBehaviour
{
    public GameObject targetObject;  // The GameObject to deactivate
    public float delay = 3.0f;       // Time in seconds before the GameObject is deactivated

    void Start()
    {
        // Start the coroutine to deactivate the GameObject after a delay
        StartCoroutine(DeactivateAfterDelay());
    }

    IEnumerator DeactivateAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Deactivate the target GameObject
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
