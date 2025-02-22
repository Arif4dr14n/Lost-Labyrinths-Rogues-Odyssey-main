using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject TurnBasedCanvas; // UI Turn-Based
    public GameObject roguelikeHUD;    // UI game utama
    public PlayerController playerController; // Referensi ke skrip kontrol pemain

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Jika pemain masuk area bos
        {
            ActivateTurnBasedMode();
        }
    }

    void ActivateTurnBasedMode()
    {
        TurnBasedCanvas.SetActive(true);  // Tampilkan UI turn-based
        roguelikeHUD.SetActive(false);    // Sembunyikan UI utama
        playerController.enabled = false; // Matikan kontrol pemain
        Time.timeScale = 0f;              // Pause gameplay real-time
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
