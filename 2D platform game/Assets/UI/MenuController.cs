﻿using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class MenuController : MonoBehaviour
{
    [Header("Menu Scenes")]
    public GameObject settingMenu;
    public GameObject mainMenu;
    public GameObject graphicMenu;
    public GameObject soundMenu;
    public GameObject loadChapterMenu;
    public GameObject controlsMenu;
    public GameObject creditsMenu;
    

    [Header("Menu First Selected Objects")]
    public GameObject settingMenuFirstSelectedButton; 
    public GameObject mainMenuFirstSelectedButton;
    public GameObject graphicMenuFirstSelectedButton;
    public GameObject soundMenuFirstSelectedButton;
    public GameObject loadChapterMenuFirstSelectedButton;


    [Header("Main Menu Buttons")]
    public GameObject playButton;
    public GameObject loadChapterButton;
    public GameObject settingsButton;
    public GameObject exitButton;


    [Header("Setting Menu Buttons")]
    public GameObject controlsButton;
    public GameObject graphicButton;
    public GameObject soundButton;
    public GameObject creditsButton;


    [Header("Graphic Menu Objects")]
    public GameObject qualityDropdown;
    public GameObject resolutionDropdown;
    public GameObject fullScreenToggle;


    [Header("Sound Menu Objects")]
    public GameObject musicVolumeSlider;
    public GameObject ambientVolumeSlider;
    public GameObject stingVolumeSlider;
    public GameObject voiceVolumeSlider;
    public GameObject playerVolumeSlider;


    [Header("Load Chapter Menu Images")]
    public GameObject prototypeLevelImage;
    public GameObject levelOneImage;
    public GameObject levelTwoImage;
    public GameObject levelThreeImage;
    public GameObject levelFourImage;

    
    [Header("Main Menu Buttons Text")]
    public TextMeshProUGUI playButtonText;
    public TextMeshProUGUI loadChapterButtonText;
    public TextMeshProUGUI settingsButtonText;
    public TextMeshProUGUI exitButtonText;

    
    [Header("Settings Menu Buttons Text")]
    public TextMeshProUGUI controlsButtonText;
    public TextMeshProUGUI graphicButtonText;
    public TextMeshProUGUI soundButtonText;
    public TextMeshProUGUI creditsButtonText;


    [Header("Graphic Menu Objects Text")]
    public TextMeshProUGUI qualityDropdownText;
    public TextMeshProUGUI resolutionDropdownText;
    public TextMeshProUGUI fullScreenToggleText;


    [Header("Sound Menu Objects Text")]
    public TextMeshProUGUI musicVolumeSliderText;
    public TextMeshProUGUI ambientVolumeSliderText;
    public TextMeshProUGUI stingVolumeSliderText;
    public TextMeshProUGUI voiceVolumeSliderText;
    public TextMeshProUGUI playerVolumeSliderText;

    
    //Current Selected Object
    GameObject currentSelected;
    GameObject settingMenuSelected;
    GameObject graphicMenuSelected;
    GameObject loadChapterSelected;
    GameObject soundMenuSelected;


    //Checking If Menu Is On Start Position
    bool mainMenuBegin = false;
    bool settingMenuBegin = false;
    bool graphicMenuBegin = false;
    bool soundMenuBegin = false;
    bool loadChapterMenuBegin = false;

    
    //Checking If We Back From Menu
    bool backFromSettings = false;
    bool backFromGraphic = false;
    bool backFromLoadChapter = false;
    bool backFromSound = false;


    //Initial Navigation For Menu
    bool maimMenuInitialNavigationPosition = true;
    bool loadChapterMenuInitialNavigationPosition = true;
    bool settingsMenuInitialNavigationPosition = true;
    bool graphicMenuInitialNavigationPosition = true;
    bool soundMenuInitialNavigationPosition = true;


    //Checking If We Played Sound Once In Main Menu
    bool playButtonPlayedOnce = false;
    bool loadChapterButtonPlayedOnce = false;
    bool settingsButtonPlayedOnce = false;
    bool exitButtonPlayedOnce = false;


    //Checking If We Played Sound Once In Load Chapter Menu
    bool prototypeLevelPlayedOnce = true;
    bool levelOnePlayedOnce = false;
    bool levelTwoPlayedOnce = false;
    bool levelThreePlayedOnce = false;
    bool levelFourPlayedOnce = false;


    //Checking If We Played Sound Once In Settings Menu
    bool controlsButtonPlayedOnce = false;
    bool graphicButtonPlayedOnce = false;
    bool soundButtonPlayedOnce = false;
    bool creditsButtonPlayedOnce = false;


    //Checking If We Played Sound Once In Graphic Menu
    bool qualityDropdownPlayedOnce = false;
    bool resolutionDropdownPlayedOnce = false;
    bool fullScreenTogglePlayedOnce = false;


    //Checking If We Played Sound Once In Sound Menu
    bool musicVolumeSliderPlayedOnce = false;
    bool ambientVolumeSliderPlayedOnce = false;
    bool stingVolumeSliderPlayedOnce = false;
    bool voiceVolumeSliderPlayedOnce = false;
    bool playerVolumeSliderPlayedOnce = false;


    //Allow Select Sound
    bool allowSelectSound = true;
    bool backFromSelect = false;

    void Update()
    {
        try
        {
            if (mainMenu.activeSelf == true)
            {
                allowSelectSound = true;
                backFromSelect = false;
                
                if(settingMenuBegin)
                {
                    if(loadChapterMenuBegin)
                    {
                        EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = loadChapterButton;
                        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                        backFromLoadChapter = true;
                        loadChapterMenuBegin = false;
                    }
                    else
                    {
                        EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingsButton;
                        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                        backFromSettings = true;
                    }
                    settingMenuBegin = false;
                    mainMenuBegin = true;
                }
                
                if (!mainMenuBegin && !backFromSettings)
                {
                    SetNewSelectedGameObject();
                    mainMenuBegin = true;
                }
                else if (mainMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                }

                if(currentSelected.name == "PlayButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(playButtonText);
                    
                    //Play only when you changed navigation in menu
                    if(!maimMenuInitialNavigationPosition && !playButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        playButtonPlayedOnce = true;
                    }
                    loadChapterButtonPlayedOnce = false;
                    settingsButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "LoadChapterButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(loadChapterButtonText);

                    //Navigation was changed
                    maimMenuInitialNavigationPosition = false;
                    //Play audio only once
                    if(!loadChapterButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        loadChapterButtonPlayedOnce = true;
                    }
                    playButtonPlayedOnce = false;  
                    settingsButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "SettingsButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(settingsButtonText);

                    //Navigation was changed
                    maimMenuInitialNavigationPosition = false;
                    if(!settingsButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();  
                        settingsButtonPlayedOnce = true;
                    }
                    playButtonPlayedOnce = false;
                    loadChapterButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;  
                }
                else if(currentSelected.name == "ExitButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(exitButtonText);

                    //Navigation was changed
                    maimMenuInitialNavigationPosition = false;
                    if(!exitButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();  
                        exitButtonPlayedOnce = true;
                    }
                    playButtonPlayedOnce = false;
                    loadChapterButtonPlayedOnce = false;
                    settingsButtonPlayedOnce = false;
                }
            }
            else if (settingMenu.activeSelf == true)
            {
                if(allowSelectSound && !backFromSelect)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = false;
                }
                else if(backFromSelect)
                {
                    allowSelectSound = false;
                }
                
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
                    if(soundMenuBegin)
                    {
                        backFromSound = true;
                    }
                }

                if (!settingMenuBegin && !backFromSettings)
                {
                    SetNewSelectedGameObject();
                    settingMenuBegin = true;
                }
                else if (settingMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    settingMenuSelected = currentSelected;
                }
            
                if(currentSelected.name == "ControlsButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(controlsButtonText);

                    //Play only when you changed navigation in menu
                    if(!settingsMenuInitialNavigationPosition && !controlsButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        controlsButtonPlayedOnce = true;
                    }
                    graphicButtonPlayedOnce = false;
                    soundButtonPlayedOnce = false;
                    creditsButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "GraphicButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(graphicButtonText);

                    settingsMenuInitialNavigationPosition = false;
                    if(!settingsMenuInitialNavigationPosition && !graphicButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        graphicButtonPlayedOnce = true;
                    }
                    controlsButtonPlayedOnce = false;
                    soundButtonPlayedOnce = false;
                    creditsButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "SoundButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(soundButtonText);

                    settingsMenuInitialNavigationPosition = false;
                    if(!settingsMenuInitialNavigationPosition && !soundButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        soundButtonPlayedOnce = true;
                    }
                    controlsButtonPlayedOnce = false;
                    graphicButtonPlayedOnce = false;
                    creditsButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "CreditsButton")
                {
                    SetDefaultColor();
                    SetHightlightColor(creditsButtonText);

                    settingsMenuInitialNavigationPosition = false;
                    if(!settingsMenuInitialNavigationPosition && !creditsButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        creditsButtonPlayedOnce = true;
                    }
                    controlsButtonPlayedOnce = false;
                    graphicButtonPlayedOnce = false;
                    soundButtonPlayedOnce = false;
                }
            }
            else if (graphicMenu.activeSelf == true)
            {
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                    backFromSelect = true;
                }
                
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
                    SetNewSelectedGameObject();
                    graphicMenuBegin = true;
                }
                else if (graphicMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    graphicMenuSelected = currentSelected;
                }
            
                if(currentSelected.name == "QualityDropdown")
                {
                    SetDefaultColor();
                    SetHightlightColor(qualityDropdownText);

                    //Play only when you changed navigation in menu
                    if(!graphicMenuInitialNavigationPosition && !qualityDropdownPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        qualityDropdownPlayedOnce = true;
                    }
                    resolutionDropdownPlayedOnce = false;
                    fullScreenTogglePlayedOnce = false;
                }
                else if(currentSelected.name == "ResolutionDropdown")
                {
                    SetDefaultColor();
                    SetHightlightColor(resolutionDropdownText);

                    graphicMenuInitialNavigationPosition = false;
                    if(!graphicMenuInitialNavigationPosition && !resolutionDropdownPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        resolutionDropdownPlayedOnce = true;
                    }
                    qualityDropdownPlayedOnce = false;
                    fullScreenTogglePlayedOnce = false;
                }
                else if(currentSelected.name == "FullScreenToggle")
                {
                    SetDefaultColor();
                    SetHightlightColor(fullScreenToggleText);

                    graphicMenuInitialNavigationPosition = false;
                    if(!graphicMenuInitialNavigationPosition && !fullScreenTogglePlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        fullScreenTogglePlayedOnce = true;
                    }
                    qualityDropdownPlayedOnce = false;
                    resolutionDropdownPlayedOnce = false;
                }
            }
            else if (soundMenu.activeSelf == true)
            {
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                }
                
                if(backFromSound)
                {
                    EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = soundMenuSelected;
                    EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                    backFromSound = false;
                    soundMenuBegin = true;
                }
                
                backFromSettings = true; //Reset Navigation For Setting Menu
                
                if (!soundMenuBegin)
                {
                    SetNewSelectedGameObject();
                    soundMenuBegin = true;
                }
                else if (soundMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    soundMenuSelected = currentSelected;
                }
                
                if(currentSelected.name == "MusicVolumeSlider")
                {
                    SetDefaultColor();
                    SetHightlightColor(musicVolumeSliderText);

                    //Play only when you changed navigation in menu
                    if(!soundMenuInitialNavigationPosition && !musicVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        musicVolumeSliderPlayedOnce = true;
                    }
                    ambientVolumeSliderPlayedOnce = false;
                    stingVolumeSliderPlayedOnce = false;
                    voiceVolumeSliderPlayedOnce = false;
                    playerVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "AmbientVolumeSlider")
                {
                    SetDefaultColor();
                    SetHightlightColor(ambientVolumeSliderText);

                    soundMenuInitialNavigationPosition = false;
                    if(!soundMenuInitialNavigationPosition && !ambientVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        ambientVolumeSliderPlayedOnce = true;
                    }
                    musicVolumeSliderPlayedOnce = false;
                    stingVolumeSliderPlayedOnce = false;
                    voiceVolumeSliderPlayedOnce = false;
                    playerVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "StingVolumeSlider")
                {
                    SetDefaultColor();
                    SetHightlightColor(stingVolumeSliderText);

                    soundMenuInitialNavigationPosition = false;
                    if(!soundMenuInitialNavigationPosition && !stingVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        stingVolumeSliderPlayedOnce = true;
                    }
                    musicVolumeSliderPlayedOnce = false;
                    ambientVolumeSliderPlayedOnce = false;
                    voiceVolumeSliderPlayedOnce = false;
                    playerVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "VoiceVolumeSlider")
                {
                    SetDefaultColor();
                    SetHightlightColor(voiceVolumeSliderText);

                    soundMenuInitialNavigationPosition = false;
                    if(!soundMenuInitialNavigationPosition && !voiceVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        voiceVolumeSliderPlayedOnce = true;
                    }
                    musicVolumeSliderPlayedOnce = false;
                    ambientVolumeSliderPlayedOnce = false;
                    stingVolumeSliderPlayedOnce = false;
                    playerVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "PlayerVolumeSlider")
                {
                    SetDefaultColor();
                    SetHightlightColor(playerVolumeSliderText);

                    soundMenuInitialNavigationPosition = false;
                    if(!soundMenuInitialNavigationPosition && !playerVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        playerVolumeSliderPlayedOnce = true;
                    }
                    musicVolumeSliderPlayedOnce = false;
                    ambientVolumeSliderPlayedOnce = false;
                    stingVolumeSliderPlayedOnce = false;
                    voiceVolumeSliderPlayedOnce = false;
                }
            }
            else if (loadChapterMenu.activeSelf == true)
            {
                if(allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = false;
                }
                
                if(backFromLoadChapter)
                {
                    EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = loadChapterSelected;
                    EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                    backFromLoadChapter = false;
                    loadChapterMenuBegin = true;
                }
                
                settingMenuBegin = true;

                if (!loadChapterMenuBegin)
                {
                    SetNewSelectedGameObject();
                    loadChapterMenuBegin = true;
                }
                else if (loadChapterMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    loadChapterSelected = currentSelected;
                }

                if(currentSelected.name == "PrototypeLevel" && loadChapterMenuBegin)
                {
                    prototypeLevelImage.SetActive(true);
                    levelOneImage.SetActive(false);
                    levelTwoImage.SetActive(false);
                    levelThreeImage.SetActive(false);
                    levelFourImage.SetActive(false);
                    
                    //Play audio only once
                    if(!loadChapterMenuInitialNavigationPosition && !prototypeLevelPlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        prototypeLevelPlayedOnce = true;
                    }

                    levelOnePlayedOnce = false;
                    levelTwoPlayedOnce = false;
                    levelThreePlayedOnce = false;
                    levelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelOne" && loadChapterMenuBegin)
                {
                    prototypeLevelImage.SetActive(false);
                    levelOneImage.SetActive(true);
                    levelTwoImage.SetActive(false);
                    levelThreeImage.SetActive(false);
                    levelFourImage.SetActive(false);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!levelOnePlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        levelOnePlayedOnce = true;
                    }

                    prototypeLevelPlayedOnce = false;
                    levelTwoPlayedOnce = false;
                    levelThreePlayedOnce = false;
                    levelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelTwo" && loadChapterMenuBegin)
                {
                    prototypeLevelImage.SetActive(false);
                    levelOneImage.SetActive(false);
                    levelTwoImage.SetActive(true);
                    levelThreeImage.SetActive(false);
                    levelFourImage.SetActive(false);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!levelTwoPlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        levelTwoPlayedOnce = true;
                    }

                    prototypeLevelPlayedOnce = false;
                    levelOnePlayedOnce = false;
                    levelThreePlayedOnce = false;
                    levelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelThree" && loadChapterMenuBegin)
                {
                    prototypeLevelImage.SetActive(false);
                    levelOneImage.SetActive(false);
                    levelTwoImage.SetActive(false);
                    levelThreeImage.SetActive(true);
                    levelFourImage.SetActive(false);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!levelThreePlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        levelThreePlayedOnce = true;
                    }

                    prototypeLevelPlayedOnce = false;
                    levelOnePlayedOnce = false;
                    levelTwoPlayedOnce = false;
                    levelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelFour" && loadChapterMenuBegin)
                {
                    prototypeLevelImage.SetActive(false);
                    levelOneImage.SetActive(false);
                    levelTwoImage.SetActive(false);
                    levelThreeImage.SetActive(false);
                    levelFourImage.SetActive(true);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!levelFourPlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        levelFourPlayedOnce = true;
                    }

                    prototypeLevelPlayedOnce = false;
                    levelOnePlayedOnce = false;
                    levelTwoPlayedOnce = false;
                    levelThreePlayedOnce = false;
                }
            }
            else if (controlsMenu.activeSelf)
            {
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                    backFromSelect = true;
                }
                
                if (!loadChapterMenuBegin)
                {
                    SetNewSelectedGameObject();
                    loadChapterMenuBegin = true;
                }
            }
            else if (creditsMenu.activeSelf)
            {
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                    backFromSelect = true;
                }
                
                if (!loadChapterMenuBegin)
                {
                    SetNewSelectedGameObject();
                    loadChapterMenuBegin = true;
                }
            }
        }
        catch (NullReferenceException) {}
    }

    void SetNewSelectedGameObject()
    {
        if (mainMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = mainMenuFirstSelectedButton;
        }
        else if (settingMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuFirstSelectedButton;
        }
        else if (graphicMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = graphicMenuFirstSelectedButton;
        }
        else if (soundMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = soundMenuFirstSelectedButton;
        }
        else if (loadChapterMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = loadChapterMenuFirstSelectedButton;
        }
        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
    }

    void SetDefaultColor()
    {
        if(mainMenu.activeSelf)
        {
            playButtonText.color = new Color32(100, 100, 100, 255);
            loadChapterButtonText.color = new Color32(100, 100, 100, 255);
            settingsButtonText.color = new Color32(100, 100, 100, 255);
            exitButtonText.color = new Color32(100, 100, 100, 255);
        }
        else if(settingMenu.activeSelf)
        {
            controlsButtonText.color = new Color32(100, 100, 100, 255);
            graphicButtonText.color = new Color32(100, 100, 100, 255);
            soundButtonText.color = new Color32(100, 100, 100, 255);
            creditsButtonText.color = new Color32(100, 100, 100, 255);
        }
        else if(graphicMenu.activeSelf)
        {
            qualityDropdownText.color = new Color32(100, 100, 100, 255);
            resolutionDropdownText.color = new Color32(100, 100, 100, 255);
            fullScreenToggleText.color = new Color32(100, 100, 100, 255);
        }
        else if(soundMenu.activeSelf)
        {
            musicVolumeSliderText.color = new Color32(100, 100, 100, 255);
            ambientVolumeSliderText.color = new Color32(100, 100, 100, 255);
            stingVolumeSliderText.color = new Color32(100, 100, 100, 255);
            voiceVolumeSliderText.color = new Color32(100, 100, 100, 255);
            playerVolumeSliderText.color = new Color32(100, 100, 100, 255);
        }
    }

    void SetHightlightColor(TextMeshProUGUI objectToHighlight)
    {
        objectToHighlight.color = new Color32(255, 255, 255, 255);
    }
}