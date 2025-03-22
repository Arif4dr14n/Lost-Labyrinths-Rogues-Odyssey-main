using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string TurnBasedSceneCave; // Nama scene tujuan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan Player memiliki tag "Player"
        {
            SessionManager.LoadTurnBasedCaveWithLoadingScreen();
        }
    }
}
