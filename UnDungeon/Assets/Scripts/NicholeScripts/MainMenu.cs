using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioManager instance = null;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Victor Test");
        instance.ChangeSound("UnDungeon");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadAbout()
    {
        SceneManager.LoadScene("AboutTest");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsTest");
    }

}
