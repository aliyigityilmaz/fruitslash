using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject mainMenu;

    private void Start()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenCredits()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseCredits()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
