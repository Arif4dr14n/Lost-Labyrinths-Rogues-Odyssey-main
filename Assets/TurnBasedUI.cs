using UnityEngine;

public class TurnBasedUI : MonoBehaviour
{
    public GameObject turnBasedUI; // Assign your Turn-Based Menu Canvas here
    private bool isMenuActive = false;
    private bool canToggle = true; // Prevents reactivation after pressing "C" once
    private bool isTurnBasedPhaseDone = false; // Tracks if the turn-based phase is finished

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canToggle)
        {
            StartTurnBasedMode();
        }

        // Automatically exit when the turn-based phase is done
        if (isTurnBasedPhaseDone)
        {
            ExitTurnBasedMode();
        }
    }

    void StartTurnBasedMode()
    {
        isMenuActive = true; // Once activated, it stays active
        turnBasedUI.SetActive(true);
        Time.timeScale = 0; // Pauses the main game

        canToggle = false; // Disables further activation of "C"

        Debug.Log("Turn-Based Mode Activated");
    }

    public void MarkTurnBasedPhaseAsDone()
    {
        isTurnBasedPhaseDone = true; // Set flag to exit turn-based mode
    }

    void ExitTurnBasedMode()
    {
        isMenuActive = false;
        turnBasedUI.SetActive(false);
        Time.timeScale = 1; // Resumes game

        canToggle = true; // Allows "C" to be used again in the future
        isTurnBasedPhaseDone = false; // Reset flag

        Debug.Log("Turn-Based Mode Deactivated");
    }
}
