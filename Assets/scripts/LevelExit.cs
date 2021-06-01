using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelExitSlowMoFactor = 0.6f;
    [SerializeField] float levelLoadDelay = 1f;

    public GameObject victoryMenu;
    //public GameObject playerButtons;
    public GameObject nextLevelButton;
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;
        
        //playerButtons.SetActive(false);
        victoryMenu.SetActive(true);
        Time.timeScale = 0f;

        if (SceneManager.GetActiveScene().name.Equals("Level3"))
        {
            nextLevelButton.SetActive(false);
        }
        
    }
}
