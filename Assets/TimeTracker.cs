// TimeTracker script
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class TimeTracker : MonoBehaviour
{
    private float startTime;
    private bool stopwatchRunning = true;  // Flag to track if the stopwatch is running

    public CombinedConditions combinedConditions;  // Reference to the CombinedConditions script
    public TextMeshProUGUI elapsedTimeText;  // Reference to the TextMeshProUGUI element

    private void Start()
    {
        startTime = Time.time;
        Debug.Log("Stopwatch started.");
    }

    private void Update()
    {
        // Check if the stopwatch is still running
        if (stopwatchRunning)
        {
            // Check conditions from CombinedConditions script
            if (combinedConditions != null && combinedConditions.AreConditionsMet())
            {
                Debug.Log("Urca conditions met. Stopping stopwatch.");
                StopStopwatch();
            }
        }
    }

    private void StopStopwatch()
    {
        float elapsedTime = Time.time - startTime;
        Debug.Log("Stopwatch stopped. Elapsed Time: " + elapsedTime.ToString("F2") + " seconds.");

        // Update the TextMeshProUGUI element with the elapsed time
        if (elapsedTimeText != null)
        {
            elapsedTimeText.text = "Elapsed Time: " + elapsedTime.ToString("F2") + " seconds";
        }

        stopwatchRunning = false;  // Set the flag to indicate the stopwatch is stopped
    }
}
