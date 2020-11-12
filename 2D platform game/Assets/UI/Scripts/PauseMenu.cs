using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    public static bool canBackToGame = true;
    public GameObject inputScript;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused && pauseMenuUI.activeSelf)
            {
                if(canBackToGame)
                {
                    canBackToGame = false;
                    Resume();
                }
                else
                {
                    canBackToGame = true;
                }
            }
            else if(!pauseMenuUI.activeSelf && !settingsMenuUI.activeSelf && !controlsMenuUI.activeSelf && !graphicMenuUI.activeSelf && !soundMenuUI.activeSelf && !creditsMenuUI.activeSelf && !LoadChapterMenuUI.activeSelf)
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
        LoadChapterMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        inputScript.GetComponent<PlayerInput>().enabled = true;
    }

    void Pause()
    {
        canBackToGame = true;
        AudioManager.PlayEnterPauseMenuAudio();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        inputScript.GetComponent<PlayerInput>().enabled = false;
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

/*     public void StartNewGame()
    {
        //to avoid menuPause restart see by player
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("PrototypeScene");
    } */
}