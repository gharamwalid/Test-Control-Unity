using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class MainMenu : MonoBehaviour
{

   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leveOne()
    {
        SceneManager.LoadScene("Playground");
    }
    public void leveTwo()
    {
        SceneManager.LoadScene("BossLevel");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToOptions()
    {
        //  mainmenuCanvas.SetActive(false);
        //optionsMenu.setActive(true);

    }

}
