using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public String levelToLoad;

    public GameObject settingsWindow;
    // Start is called before the first frame update

    private void Update()
    {
        if (settingsWindow.activeInHierarchy && Input.GetKey(KeyCode.Escape))
        {
            CloseSettingWindow();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Settings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credit");
    }
}
