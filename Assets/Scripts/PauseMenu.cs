using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseWindow;
    public GameObject settingWindow;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                if (!settingWindow.activeInHierarchy)
                {
                    ResumeGame();
                }
                else
                {
                    CloseSettings();
                }
                
            }
            else
            {
                PauseGame();
            }

        }
        
    }

    public void PauseGame()
    {
        PlayerMovement.instance.enabled = false;
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        PlayerMovement.instance.enabled = true;
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettings()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingWindow.SetActive(false);
        
    }
}
