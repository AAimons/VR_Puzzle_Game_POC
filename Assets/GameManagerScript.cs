// CombinedConditions script
using UnityEngine;

public class CombinedConditions : MonoBehaviour
{
    public CameraTrigger triggerScript;
    public CameraLookAt lookAtScript;
    public GameObject cubePrefab;
    public GameObject uiPrefab;

    public float delayDuration = 3f;  // Set the desired delay duration in seconds.

    public Vector3 uiSpawnPosition = new Vector3(3.69f, 0.07f, 0.32f);

    private bool conditionsMet = false;
    private bool uiPrefabSpawned = false;
    private float timer = 0f;

    // Public method to get the value of conditionsMet
    public bool AreConditionsMet()
    {
        return conditionsMet;
    }

    private void Update()
    {
        if (triggerScript.IsCameraInTriggerArea() && lookAtScript.IsCameraLookingAtTarget())
        {
            if (!conditionsMet)
            {
                conditionsMet = true;
                Debug.Log("Urca");
                timer = 0f;  // Reset the timer when conditions are met.
            }
            else
            {
                timer += Time.deltaTime;  // Increment the timer while conditions are continuously met.
                if (timer >= delayDuration && !uiPrefabSpawned)
                {
                    // Conditions have been met continuously for the specified duration.

                    // Spawn the UI prefab only if it hasn't been spawned before
                    if (!uiPrefabSpawned)
                    {
                        SpawnPrefab();
                        uiPrefabSpawned = true; // Set the flag to indicate UI prefab has been spawned
                    }
                }
            }
        }
        else
        {
            conditionsMet = false;
            timer = 0f;  // Reset the timer when conditions are not met.
        }
    }

    private void SpawnPrefab()
    {
        // Instantiate the UI prefab at the specified position.
        Instantiate(uiPrefab, uiSpawnPosition, Quaternion.identity);

        // Reset the conditions and timer.
        conditionsMet = false;
        timer = 0f;
    }
}
