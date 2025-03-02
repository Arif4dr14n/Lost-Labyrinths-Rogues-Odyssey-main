using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnBasedTrigger2D : MonoBehaviour
{
    private bool playerInZone = false;
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        // Hanya bisa menekan C jika berada di dalam zona
        if (playerInZone && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(LoadLevelWithTransition());
        }
    }

    IEnumerator LoadLevelWithTransition()
    {
        // Mainkan animasi transisi
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }

        // Tunggu selama transisi berlangsung
        yield return new WaitForSeconds(transitionTime);

        // Panggil metode untuk memuat level turn-based
        SessionManager.LoadTurnBasedCaveWithLoadingScreen();
    }

    // Ketika pemain masuk ke zona trigger (2D)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    // Ketika pemain keluar dari zona trigger (2D)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}
