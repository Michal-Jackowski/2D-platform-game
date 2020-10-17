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
    GameObject loadChapterSelected;
    GameObject soundMenuSelected;


    bool mainMenuBegin = false;
    bool settingMenuBegin = false;
    bool graphicMenuBegin = false;
    bool soundMenuBegin = false;
    bool loadChapterMenuBegin = false;

    
    bool backFromSettings = false;
    bool backFromGraphic = false;
    bool backFromLoadChapter = false;
    bool backFromSound = false;


    bool maimMenuInitialNavigationPosition = true;
    bool loadChapterMenuInitialNavigationPosition = true;
    bool settingsMenuInitialNavigationPosition = true;

    //Main Menu
    bool PlayButtonPlayedOnce = false;
    bool LoadChapterButtonPlayedOnce = false;
    bool SettingsButtonPlayedOnce = false;
    bool ExitButtonPlayedOnce = false;

    //Load Chapter Menu
    bool PrototypeLevelPlayedOnce = true;
    bool LevelOnePlayedOnce = false;
    bool LevelTwoPlayedOnce = false;
    bool LevelThreePlayedOnce = false;
    bool LevelFourPlayedOnce = false;

    //Settings Menu
    bool ControlsButtonPlayedOnce = false;
    bool GraphicButtonPlayedOnce = false;
    bool SoundButtonPlayedOnce = false;
    bool CreditsButtonPlayedOnce = false;


    void Update()
    {
        try
        {
            if (mainMenu.activeSelf == true)
            {
                if(settingMenuBegin)
                {
                    if(loadChapterMenuBegin)
                    {
                        EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = LoadChapterButton;
                        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                        backFromLoadChapter = true;
                        loadChapterMenuBegin = false;
                    }
                    else
                    {
                        EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = SettingsButton;
                        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                        backFromSettings = true;
                    }
                    settingMenuBegin = false;
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
                    //Play only when you changed navigation in menu
                    if(!maimMenuInitialNavigationPosition && !PlayButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        PlayButtonPlayedOnce = true;
                    }
                    LoadChapterButtonPlayedOnce = false;
                    SoundButtonPlayedOnce = false;
                    ExitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "LoadChapterButton")
                {
                    PlayButtonText.color = new Color32(100, 100, 100, 255);
                    LoadChapterButtonText.color = new Color32(255, 255, 255, 255);
                    SettingsButtonText.color = new Color32(100, 100, 100, 255);
                    ExitButtonText.color = new Color32(100, 100, 100, 255);
                    //Navigation was changed
                    maimMenuInitialNavigationPosition = false;
                    //Play audio only once
                    if(!LoadChapterButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        LoadChapterButtonPlayedOnce = true;
                    }
                    PlayButtonPlayedOnce = false;  
                    SoundButtonPlayedOnce = false;
                    ExitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "SettingsButton")
                {
                    PlayButtonText.color = new Color32(100, 100, 100, 255);
                    LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                    SettingsButtonText.color = new Color32(255, 255, 255, 255);
                    ExitButtonText.color = new Color32(100, 100, 100, 255);
                    //Navigation was changed
                    maimMenuInitialNavigationPosition = false;
                    if(!SoundButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();  
                        SoundButtonPlayedOnce = true;
                    }
                    PlayButtonPlayedOnce = false;
                    LoadChapterButtonPlayedOnce = false;
                    ExitButtonPlayedOnce = false;  
                }
                else if(currentSelected.name == "ExitButton")
                {
                    PlayButtonText.color = new Color32(100, 100, 100, 255);
                    LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                    SettingsButtonText.color = new Color32(100, 100, 100, 255);
                    ExitButtonText.color = new Color32(255, 255, 255, 255);
                    //Navigation was changed
                    maimMenuInitialNavigationPosition = false;
                    if(!ExitButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();  
                        ExitButtonPlayedOnce = true;
                    }
                    PlayButtonPlayedOnce = false;
                    LoadChapterButtonPlayedOnce = false;
                    SoundButtonPlayedOnce = false;
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
                    if(soundMenuBegin)
                    {
                        backFromSound = true;
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
                    //Play only when you changed navigation in menu
                    if(!settingsMenuInitialNavigationPosition && !ControlsButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        ControlsButtonPlayedOnce = true;
                    }
                    GraphicButtonPlayedOnce = false;
                    SoundButtonPlayedOnce = false;
                    CreditsButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "GraphicButton")
                {
                    ControlsButtonText.color = new Color32(100, 100, 100, 255);
                    GraphicButtonText.color = new Color32(255, 255, 255, 255);
                    SoundButtonText.color = new Color32(100, 100, 100, 255);
                    CreditsButtonText.color = new Color32(100, 100, 100, 255);
                    settingsMenuInitialNavigationPosition = false;
                    if(!settingsMenuInitialNavigationPosition && !GraphicButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        GraphicButtonPlayedOnce = true;
                    }
                    ControlsButtonPlayedOnce = false;
                    SoundButtonPlayedOnce = false;
                    CreditsButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "SoundButton")
                {
                    ControlsButtonText.color = new Color32(100, 100, 100, 255);
                    GraphicButtonText.color = new Color32(100, 100, 100, 255);
                    SoundButtonText.color = new Color32(255, 255, 255, 255);
                    CreditsButtonText.color = new Color32(100, 100, 100, 255);
                    settingsMenuInitialNavigationPosition = false;
                    if(!settingsMenuInitialNavigationPosition && !SoundButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        SoundButtonPlayedOnce = true;
                    }
                    ControlsButtonPlayedOnce = false;
                    GraphicButtonPlayedOnce = false;
                    CreditsButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "CreditsButton")
                {
                    ControlsButtonText.color = new Color32(100, 100, 100, 255);
                    GraphicButtonText.color = new Color32(100, 100, 100, 255);
                    SoundButtonText.color = new Color32(100, 100, 100, 255);
                    CreditsButtonText.color = new Color32(255, 255, 255, 255);
                    settingsMenuInitialNavigationPosition = false;
                    if(!settingsMenuInitialNavigationPosition && !CreditsButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        CreditsButtonPlayedOnce = true;
                    }
                    ControlsButtonPlayedOnce = false;
                    GraphicButtonPlayedOnce = false;
                    SoundButtonPlayedOnce = false;
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
                    ChangeAndSetFirstSelectedObject();
                    soundMenuBegin = true;
                }
                else if (soundMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    soundMenuSelected = currentSelected;
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
                    ChangeAndSetFirstSelectedObject();
                    loadChapterMenuBegin = true;
                }
                else if (loadChapterMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                    loadChapterSelected = currentSelected;
                }

                if(currentSelected.name == "PrototypeLevel" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(true);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(false);
                    
                    //Play audio only once
                    if(!loadChapterMenuInitialNavigationPosition && !PrototypeLevelPlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        PrototypeLevelPlayedOnce = true;
                    }

                    LevelOnePlayedOnce = false;
                    LevelTwoPlayedOnce = false;
                    LevelThreePlayedOnce = false;
                    LevelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelOne" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(true);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(false);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!LevelOnePlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        LevelOnePlayedOnce = true;
                    }

                    PrototypeLevelPlayedOnce = false;
                    LevelTwoPlayedOnce = false;
                    LevelThreePlayedOnce = false;
                    LevelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelTwo" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(true);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(false);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!LevelTwoPlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        LevelTwoPlayedOnce = true;
                    }

                    PrototypeLevelPlayedOnce = false;
                    LevelOnePlayedOnce = false;
                    LevelThreePlayedOnce = false;
                    LevelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelThree" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(true);
                    LevelFourImage.SetActive(false);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!LevelThreePlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        LevelThreePlayedOnce = true;
                    }

                    PrototypeLevelPlayedOnce = false;
                    LevelOnePlayedOnce = false;
                    LevelTwoPlayedOnce = false;
                    LevelFourPlayedOnce = false;
                }
                if(currentSelected.name == "LevelFour" && loadChapterMenuBegin)
                {
                    PrototypeLevelImage.SetActive(false);
                    LevelOneImage.SetActive(false);
                    LevelTwoImage.SetActive(false);
                    LevelThreeImage.SetActive(false);
                    LevelFourImage.SetActive(true);
                    
                    //Navigation was changed
                    loadChapterMenuInitialNavigationPosition = false;

                    if(!LevelFourPlayedOnce)
                    {
                        AudioManager.PlayLeftRightMenuNavigationAudio();
                        LevelFourPlayedOnce = true;
                    }

                    PrototypeLevelPlayedOnce = false;
                    LevelOnePlayedOnce = false;
                    LevelTwoPlayedOnce = false;
                    LevelThreePlayedOnce = false;
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