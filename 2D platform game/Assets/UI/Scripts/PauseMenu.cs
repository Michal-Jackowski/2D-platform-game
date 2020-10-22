using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject controlsMenuUI;
    public GameObject graphicMenuUI;
    public GameObject soundMenuUI;
    public GameObject creditsMenuUI;
    public GameObject LoadChapterMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuUI.activeSelf)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenuUI.activeSelf && GameIsPaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        graphicMenuUI.SetActive(false);
        soundMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
        LoadChapterMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }

    public void StartNewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PrototypeScene");
    }
}
