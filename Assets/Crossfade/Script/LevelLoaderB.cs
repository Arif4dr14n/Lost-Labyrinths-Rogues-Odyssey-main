using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderB : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(LoadLevelWithTransition());
        }
    }

    IEnumerator LoadLevelWithTransition()
    {
        // Mainkan animasi transisi
        transition.SetTrigger("Start");

        // Tunggu selama transisi berlangsung
        yield return new WaitForSeconds(transitionTime);

        // Panggil metode untuk memuat level
        SessionManager.LoadTurnBasedBasementWithLoadingScreen();
    }
}