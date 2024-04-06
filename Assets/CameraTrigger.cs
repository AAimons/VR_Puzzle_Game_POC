using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private bool inTriggerArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Assuming the main camera has a "MainCamera" tag
        {
            inTriggerArea = true;
            Debug.Log("Main camera entered the trigger area.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inTriggerArea = false;
            Debug.Log("Main camera exited the trigger area.");
        }
    }

    public bool IsCameraInTriggerArea()
    {
        return inTriggerArea;
    }
}
