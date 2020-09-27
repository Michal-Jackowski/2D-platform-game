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
    public GameObject LoadChapterMenu0UI;
    public GameObject LoadChapterMenu1UI;
    public GameObject LoadChapterMenu2UI;
    public GameObject LoadChapterMenu3UI;
    public GameObject LoadChapterMenu4UI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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
        LoadChapterMenu0UI.SetActive(false);
        LoadChapterMenu1UI.SetActive(false);
        LoadChapterMenu2UI.SetActive(false);
        LoadChapterMenu3UI.SetActive(false);
        LoadChapterMenu4UI.SetActive(false);
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
