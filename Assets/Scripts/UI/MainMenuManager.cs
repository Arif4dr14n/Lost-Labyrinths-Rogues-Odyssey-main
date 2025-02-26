using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject volumeSetting;
    public GameObject graphicSetting;
    public GameObject controlSetting;

    public GameObject volumeButton;
    public GameObject graphicButton;
    public GameObject controlButton;

    public static bool isSettingsOpen;

    public Color selectedColor = Color.white;
    public Color defaultColor = Color.black;

    private TMP_Text volumeText;
    private TMP_Text graphicText;
    private TMP_Text controlText;

    // Start is called before the first frame update
    void Awake()
    {
        isSettingsOpen = false;
        settingsCanvas.SetActive(false);
        volumeText = volumeButton.GetComponentInChildren<TMP_Text>();
        graphicText = graphicButton.GetComponentInChildren<TMP_Text>();
        controlText = controlButton.GetComponentInChildren<TMP_Text>();
    }

    private void OpenSettings()
    {
        settingsCanvas.SetActive(true);
        volumeSetting.SetActive(true);
        volumeText.color = selectedColor;
    }

    public void OpenVolume()
    {
        volumeSetting.SetActive(true);
        controlSetting.SetActive(false);
        graphicSetting.SetActive(false);
        volumeText.color = selectedColor;
        controlText.color = defaultColor;
        graphicText.color = defaultColor;
    }

    public void OpenGraphic()
    {
        volumeSetting.SetActive(false);
        controlSetting.SetActive(false);
        graphicSetting.SetActive(true);
        volumeText.color = defaultColor;
        controlText.color = defaultColor;
        graphicText.color = selectedColor;
    }

    public void OpenControl()
    {
        volumeSetting.SetActive(false);
        controlSetting.SetActive(true);
        graphicSetting.SetActive(false);
        volumeText.color = defaultColor;
        controlText.color = selectedColor;
        graphicText.color = defaultColor;
    }

    private void CloseSettings()
    {
        settingsCanvas.SetActive(false);
        controlSetting.SetActive(false);
        graphicSetting.SetActive(false);
        volumeSetting.SetActive(false);
        volumeText.color = defaultColor;
        controlText.color = defaultColor;
        graphicText.color = defaultColor;
    }
    public void toggleSettingsMenu()
    {
        if (isSettingsOpen)
            {
                CloseSettings();
            }
            else
            {
                OpenSettings();
            }

            isSettingsOpen = !isSettingsOpen;
    }

    public void toggleSettingsMenu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isSettingsOpen)
            {
                CloseSettings();
            }
            else
            {
                OpenSettings();
            }

            isSettingsOpen = !isSettingsOpen;
        }
    }

    public void StartNewGame()
    {
        SessionManager.StartNewSession();
        SessionManager.LoadNextLevelWithLoadingScreen();
    }

    public void Exit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
