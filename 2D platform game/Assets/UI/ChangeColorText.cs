using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ChangeColorText : MonoBehaviour
{
    [Header("Menu Scenes")]
    public GameObject settingMenu;
    public GameObject mainMenu;


    [Header("Menu FirstSelectedObjects")]
    public GameObject settingMenuFirstSelectedButton; 
    public GameObject mainMenuFirstSelectedButton;


    [Header("Main Menu Buttons")]
    public GameObject PlayButton;
    public GameObject LoadChapterButton;
    public GameObject SettingsButton;
    public GameObject ExitButton;

    
    [Header("Main Menu Buttons Text")]
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI LoadChapterButtonText;
    public TextMeshProUGUI SettingsButtonText;
    public TextMeshProUGUI ExitButtonText;

    
    [Header("Settings Menu Buttons Text")]
    public TextMeshProUGUI ControlsButton;
    public TextMeshProUGUI GraphicButton;
    public TextMeshProUGUI SoundButton;
    public TextMeshProUGUI CreditsButton;


    GameObject currentSelected;


    bool mainMenuBegin = false;
    bool settingMenuBegin = false;


    void Update()
    {
        try
        {
            if (mainMenu.activeSelf == true)
            {
/*                 if(settingMenuBegin)
                {
                    EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().currentSelectedGameObject);
                } */
                
                if (!mainMenuBegin)
                {
                    ChangeAndSetFirstSelectedObject();
                    mainMenuBegin = true;
                }
                else if (mainMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                }

                if(currentSelected.name == "PlayButton")
                {
                    PlayButtonText.color = new Color32(255, 255, 255, 255);
                    LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                    SettingsButtonText.color = new Color32(100, 100, 100, 255);
                    ExitButtonText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "LoadChapterButton")
                {
                    PlayButtonText.color = new Color32(100, 100, 100, 255);
                    LoadChapterButtonText.color = new Color32(255, 255, 255, 255);
                    SettingsButtonText.color = new Color32(100, 100, 100, 255);
                    ExitButtonText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "SettingsButton")
                {
                    PlayButtonText.color = new Color32(100, 100, 100, 255);
                    LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                    SettingsButtonText.color = new Color32(255, 255, 255, 255);
                    ExitButtonText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "ExitButton")
                {
                    PlayButtonText.color = new Color32(100, 100, 100, 255);
                    LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                    SettingsButtonText.color = new Color32(100, 100, 100, 255);
                    ExitButtonText.color = new Color32(255, 255, 255, 255);
                }
                else
                {
                    Debug.Log("Another state mainMenu");
                }
            }
            else if (settingMenu.activeSelf == true)
            {
                mainMenuBegin = false;

                if (!settingMenuBegin)
                {
                    ChangeAndSetFirstSelectedObject();
                    settingMenuBegin = true;
                }
                else
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                }
            
                if(currentSelected.name == "ControlsButton")
                {
                    ControlsButton.color = new Color32(255, 255, 255, 255);
                    GraphicButton.color = new Color32(100, 100, 100, 255);
                    SoundButton.color = new Color32(100, 100, 100, 255);
                    CreditsButton.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "GraphicButton")
                {
                    ControlsButton.color = new Color32(100, 100, 100, 255);
                    GraphicButton.color = new Color32(255, 255, 255, 255);
                    SoundButton.color = new Color32(100, 100, 100, 255);
                    CreditsButton.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "SoundButton")
                {
                    ControlsButton.color = new Color32(100, 100, 100, 255);
                    GraphicButton.color = new Color32(100, 100, 100, 255);
                    SoundButton.color = new Color32(255, 255, 255, 255);
                    CreditsButton.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "CreditsButton")
                {
                    ControlsButton.color = new Color32(100, 100, 100, 255);
                    GraphicButton.color = new Color32(100, 100, 100, 255);
                    SoundButton.color = new Color32(100, 100, 100, 255);
                    CreditsButton.color = new Color32(255, 255, 255, 255);
                }
                else
                {
                    Debug.Log("Another state settingMenu");
                }
            }
        }
        catch (NullReferenceException) {}
    }

    void ChangeAndSetFirstSelectedObject()
    {
        if (mainMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = mainMenuFirstSelectedButton;
            EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
        }
        else if (settingMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuFirstSelectedButton;
            EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
        }
    }
}