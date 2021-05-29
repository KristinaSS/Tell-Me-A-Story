using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public void PlayGame1Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PlayGame1Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void PlayGame1Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

   
}
