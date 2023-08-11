using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotKeys : MonoBehaviour
{
    public GameObject MenuForMenu;
    public bool LetsGo = false;
    public void ClickOnMainMenu()
    {
            MenuForMenu.SetActive(true);
    }


    public void ClickOnYesMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ClickOnNoMenu()
    {
        MenuForMenu.SetActive(false);
    }


}
