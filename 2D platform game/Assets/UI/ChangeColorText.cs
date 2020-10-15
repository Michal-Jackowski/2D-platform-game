﻿using System.Collections;
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
    public GameObject graphicMenu;
    public GameObject soundMenu;
    public GameObject loadChapterMenu;
    


    [Header("Menu FirstSelectedObjects")]
    public GameObject settingMenuFirstSelectedButton; 
    public GameObject mainMenuFirstSelectedButton;
    public GameObject graphicMenuFirstSelectedButton;
    public GameObject soundMenuFirstSelectedButton;
    public GameObject loadChapterMenuFirstSelectedButton;



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


    [Header("Graphic Menu Objects")]
    public GameObject QualityDropdown;
    public GameObject ResolutionDropdown;
    public GameObject FullScreenToggle;


    [Header("Sound Menu Objects")]
    public GameObject MusicVolumeSlider;
    public GameObject AmbientVolumeSlider;
    public GameObject StingVolumeSlider;
    public GameObject VoiceVolumeSlider;
    public GameObject PlayerVolumeSlider;


    [Header("Load Chapter Menu Images")]
    public GameObject PrototypeLevelImage;
    public GameObject LevelOneImage;
    public GameObject LevelTwoImage;
    public GameObject LevelThreeImage;
    public GameObject LevelFourImage;

    
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


    [Header("Graphic Menu Object Text")]
    public TextMeshProUGUI QualityDropdownText;
    public TextMeshProUGUI ResolutionDropdownText;
    public TextMeshProUGUI FullScreenToggleText;


    [Header("Sound Menu Object Text")]
    public TextMeshProUGUI MusicVolumeSliderText;
    public TextMeshProUGUI AmbientVolumeSliderText;
    public TextMeshProUGUI StingVolumeSliderText;
    public TextMeshProUGUI VoiceVolumeSliderText;
    public TextMeshProUGUI PlayerVolumeSliderText;


    GameObject currentSelected;
    GameObject settingMenuSelected;
    GameObject graphicMenuSelected;


    bool mainMenuBegin = false;
    bool settingMenuBegin = false;
    bool graphicMenuBegin = false;
    bool soundMenuBegin = false;
    bool loadChapterMenuBegin = false;


    bool backFromSettings = false;
    bool backFromGraphic = false;

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
                    if(graphicMenuBegin)
                    {
                        backFromGraphic = true;
                    }
                }

                if (!settingMenuBegin && !backFromSettings)
                {
                    ChangeAndSetFirstSelectedObject();
                    settingMenuBegin = true;
                }
                else if (settingMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    settingMenuSelected = currentSelected;
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
            else if (graphicMenu.activeSelf == true)
            {
                if(backFromGraphic)
                {
                    EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = graphicMenuSelected;
                    EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                    backFromGraphic = false;
                    graphicMenuBegin = true;
                }
                
                backFromSettings = true; //Reset Navigation For Setting Menu
                
                if (!graphicMenuBegin)
                {
                    ChangeAndSetFirstSelectedObject();
                    graphicMenuBegin = true;
                }
                else if (graphicMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    graphicMenuSelected = currentSelected;
                    Debug.Log("TEST...");
                }
            
                if(currentSelected.name == "QualityDropdown")
                {
                    QualityDropdownText.color = new Color32(255, 255, 255, 255);
                    ResolutionDropdownText.color = new Color32(100, 100, 100, 255);
                    FullScreenToggleText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "ResolutionDropdown")
                {
                    QualityDropdownText.color = new Color32(100, 100, 100, 255);
                    ResolutionDropdownText.color = new Color32(255, 255, 255, 255);
                    FullScreenToggleText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "FullScreenToggle")
                {
                    QualityDropdownText.color = new Color32(100, 100, 100, 255);
                    ResolutionDropdownText.color = new Color32(100, 100, 100, 255);
                    FullScreenToggleText.color = new Color32(255, 255, 255, 255);
                }
            }
            else if (soundMenu.activeSelf == true)
            {
                if (!soundMenuBegin)
                {
                    ChangeAndSetFirstSelectedObject();
                    soundMenuBegin = true;
                }
                else if (soundMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                }
                
                if(currentSelected.name == "MusicVolumeSlider")
                {
                    MusicVolumeSliderText.color = new Color32(255, 255, 255, 255);
                    AmbientVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    StingVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    VoiceVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    PlayerVolumeSliderText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "AmbientVolumeSlider")
                {
                    MusicVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    AmbientVolumeSliderText.color = new Color32(255, 255, 255, 255);
                    StingVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    VoiceVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    PlayerVolumeSliderText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "StingVolumeSlider")
                {
                    MusicVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    AmbientVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    StingVolumeSliderText.color = new Color32(255, 255, 255, 255);
                    VoiceVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    PlayerVolumeSliderText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "VoiceVolumeSlider")
                {
                    MusicVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    AmbientVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    StingVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    VoiceVolumeSliderText.color = new Color32(255, 255, 255, 255);
                    PlayerVolumeSliderText.color = new Color32(100, 100, 100, 255);
                }
                else if(currentSelected.name == "PlayerVolumeSlider")
                {
                    MusicVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    AmbientVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    StingVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    VoiceVolumeSliderText.color = new Color32(100, 100, 100, 255);
                    PlayerVolumeSliderText.color = new Color32(255, 255, 255, 255);
                }
            }
            else if (loadChapterMenu.activeSelf == true)
            {
                if (!loadChapterMenuBegin)
                {
                    ChangeAndSetFirstSelectedObject();
                    loadChapterMenuBegin = true;
                }
                else if (loadChapterMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                }

                if(currentSelected.name == "PrototypeLevel" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(true);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(false);
                    //Debug.Log("PrototypeLevel IF");
                }
                if(currentSelected.name == "LevelOne" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(true);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(false);
                    //Debug.Log("LevelOne IF");
                }
                if(currentSelected.name == "LevelTwo" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(true);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(false);
                    //Debug.Log("LevelTwo IF");
                }
                if(currentSelected.name == "LevelThree" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(true);
                    LevelFourImage.SetActive(false);
                    //Debug.Log("LevelThree IF");
                }
                if(currentSelected.name == "LevelFour" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(true);
                    //Debug.Log("LevelFour IF");
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
        }
        else if (settingMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuFirstSelectedButton;
        }
        else if (graphicMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = graphicMenuFirstSelectedButton;
        }
        else if (soundMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = soundMenuFirstSelectedButton;
        }
        else if (loadChapterMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = loadChapterMenuFirstSelectedButton;
        }
        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
    }
}