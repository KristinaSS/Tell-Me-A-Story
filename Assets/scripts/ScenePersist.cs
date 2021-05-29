using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePersist : MonoBehaviour
{
    int startingSceneIndex;
    private void Awake() //very first thing that happens 
    {
        int numScenePersist = FindObjectsOfType<GameSession>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
