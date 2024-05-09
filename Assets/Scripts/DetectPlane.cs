using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlane : MonoBehaviour
{
    public float raycastDistance = 1.0f;
    private string planeName;

    void Update()
    {
        RaycastHit hit;

        // Raycast downwards from the cube
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            // Check if the hit object has a collider
            if (hit.collider != null)
            {
                // Check if the collider is attached to a GameObject with a Plane tag
                if (hit.collider.gameObject.CompareTag("Plane"))
                {
                    planeName = hit.collider.gameObject.name;
                    Debug.Log("Plane name: " + planeName); // Debug message for testing
                }
            }
        }
        else
        {
            planeName = ""; // Reset plane name if no plane detected
        }
    }

    public string GetPlaneName()
    {
        return planeName;
    }
}
