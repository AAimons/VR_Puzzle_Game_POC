using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform cameraTransform; // Assign your Main Camera's transform in the Inspector.
    public Transform targetObject;   // Assign the target object's transform in the Inspector.
    public float detectionRadius = 20f; // Adjust the detection radius as needed.

    private void Update()
    {
        if (IsCameraLookingAtTarget())
        {
            Debug.Log("Main Camera is looking at the target object!");
            // You can perform additional actions here.
        }
    }

    public bool IsCameraLookingAtTarget()
    {
        if (cameraTransform == null || targetObject == null)
        {
            Debug.LogWarning("Camera or target object not assigned.");
            return false;
        }

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraToTarget = targetObject.position - cameraTransform.position;
        float angle = Vector3.Angle(cameraForward, cameraToTarget);

        return angle < detectionRadius;
    }
}
