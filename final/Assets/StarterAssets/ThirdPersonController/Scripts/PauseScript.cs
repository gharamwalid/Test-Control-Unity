using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class PauseScript : MonoBehaviour
{


    public GameObject PauseScreen;
    bool GamePaused;
    public GameObject PausedButton;
    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
           
        
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PausedButton.SetActive(false);
    }
    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PausedButton.SetActive(true);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
