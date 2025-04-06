using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition2 : MonoBehaviour
{
    [SerializeField] private string TurnBasedScene; // Nama scene tujuan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan Player memiliki tag "Player"
        {
            SessionManager.LoadTurnBasedLabWithLoadingScreen();
        }
    }
}
