using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject knappen;
    public GameObject bakgrund;
    public GameObject GameisOver;
    public GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        
        knappen.SetActive(false);
        bakgrund.SetActive(false);
        GameisOver.SetActive(false);
        Score.SetActive(false);
        Time.timeScale = 1;

    }

    

    // Update is called once per frame
    void Update()
    {
       
    }

    public  void RestartTheGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void GameOverUI()
    {
        Time.timeScale = 0;
        knappen.SetActive(true);
        bakgrund.SetActive(true);
        GameisOver.SetActive(true);
        Score.SetActive(true);
    }
}
