using UnityEngine;

public class TurnBaseTrigger : MonoBehaviour
{
    public GameObject turnBasedCanvas; // UI Turn-Based
    public GameObject roguelikeHUD; // UI game utama

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateTurnBasedMode();
        }
    }

    void ActivateTurnBasedMode()
    {
        turnBasedCanvas.SetActive(true);  // Aktifkan UI Turn-Based
        roguelikeHUD.SetActive(false);    // Sembunyikan UI game utama
        Time.timeScale = 0f;              // Pause gameplay real-time
    }
}
