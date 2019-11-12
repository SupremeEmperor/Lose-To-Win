using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Victor Test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
