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


    [Header("Setting Menu Buttons")]
    public GameObject ControlsButton;
    public GameObject GraphicButton;
    public GameObject SoundButton;
    public GameObject CreditsButton;

    
    [Header("Main Menu Buttons Text")]
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI LoadChapterButtonText;
    public TextMeshProUGUI SettingsButtonText;
    public TextMeshProUGUI ExitButtonText;

    
    [Header("Settings Menu Buttons Text")]
    public TextMeshProUGUI ControlsButtonText;
    public TextMeshProUGUI GraphicButtonText;
    public TextMeshProUGUI SoundButtonText;
    public TextMeshProUGUI CreditsButtonText;


    GameObject currentSelected;
    GameObject settingMenuSelected;


    bool mainMenuBegin = false;
    bool settingMenuBegin = false;
    bool backFromSettings = false;


    void Update()
    {
        try
        {
            if (mainMenu.activeSelf == true)
            {
                if(settingMenuBegin)
                {
                    EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = SettingsButton;
                    EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                    settingMenuBegin = false;
                    backFromSettings = true;
                    mainMenuBegin = true;
                }
                
                if (!mainMenuBegin && !backFromSettings)
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
            }
            else if (settingMenu.activeSelf == true)
            {
                if(backFromSettings)
                {
                    EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuSelected;
                    EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                    settingMenuBegin = true;
                    backFromSettings = false;
                }
                
                mainMenuBegin = false;

                if (!settingMenuBegin && !backFromSettings)
                {
                    ChangeAndSetFirstSelectedObject();
                    settingMenuBegin = true;
                }
                else if (settingMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    settingMenuSelected = currentSelected;
                    //Debug.Log("Stuck");
                }
            
                if(currentSelected.name == "ControlsButton")
                {
                    ControlsButtonText.color = new Color32(255, 255, 255, 255);
                    GraphicButtonText.color = new Color32(100, 100, 100, 255);
                    SoundButtonText.color = new Color32(100, 100, 100, 255);
                    CreditsButtonText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "GraphicButton")
                {
                    ControlsButtonText.color = new Color32(100, 100, 100, 255);
                    GraphicButtonText.color = new Color32(255, 255, 255, 255);
                    SoundButtonText.color = new Color32(100, 100, 100, 255);
                    CreditsButtonText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "SoundButton")
                {
                    ControlsButtonText.color = new Color32(100, 100, 100, 255);
                    GraphicButtonText.color = new Color32(100, 100, 100, 255);
                    SoundButtonText.color = new Color32(255, 255, 255, 255);
                    CreditsButtonText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "CreditsButton")
                {
                    ControlsButtonText.color = new Color32(100, 100, 100, 255);
                    GraphicButtonText.color = new Color32(100, 100, 100, 255);
                    SoundButtonText.color = new Color32(100, 100, 100, 255);
                    CreditsButtonText.color = new Color32(255, 255, 255, 255);
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