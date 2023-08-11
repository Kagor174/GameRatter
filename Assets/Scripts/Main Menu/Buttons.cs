using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject aboutWindow;
    public GameObject settingsWindow;
    public void ClickOnNewGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void ClickOnAbout()
    {
        settingsWindow.SetActive(false);
        aboutWindow.SetActive(!aboutWindow.activeSelf);
    }

    public void ClickOnSettings()
    {
        aboutWindow.SetActive(false);
        settingsWindow.SetActive(!settingsWindow.activeSelf);
    }

    public void ClickOnExit()
    {
        Application.Quit();

    }

    public void ClickOnCloseAbout()
    {
        aboutWindow.SetActive(false);
    }

    public void ClickOnCloseSet()
    {
        settingsWindow.SetActive(false);
    }
}
