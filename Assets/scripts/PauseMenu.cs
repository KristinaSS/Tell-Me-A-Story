using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject storyPanel;
    public GameObject endStoryPanel;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void GoToMenu()
    {
        Debug.Log("Entering game menu...");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        
        if (SceneManager.GetActiveScene().name.Equals("Level3"))
        {
            endStoryPanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void GoToNextLevel()
    {
        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        
    }

    public void ClickNext()
    {
        storyPanel.SetActive(false);
    }
}
