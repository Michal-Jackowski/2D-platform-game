using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PauseMenuManagerNew : MonoBehaviour
{
    [Header("Menu Scenes")]
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject graphicMenu;
    public GameObject soundMenu;
    public GameObject loadChapterMenu;
    public GameObject controlsMenu;
    public GameObject creditsMenu;
    

    [Header("Menu First Selected Objects")]
    public GameObject settingMenuFirstSelectedButton; 
    public GameObject pauseMenuFirstSelectedButton;
    public GameObject graphicMenuFirstSelectedButton;
    public GameObject soundMenuFirstSelectedButton;
    public GameObject loadChapterMenuFirstSelectedButton;


    [Header("Pause Menu Buttons")]
    public GameObject resumeButton;
    public GameObject startNewGameButton;
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
    public GameObject postProcessingToggle;
    public GameObject brightnessVolumeSlider;


    [Header("Sound Menu Objects")]
    public GameObject musicVolumeSlider;
    public GameObject ambientVolumeSlider;
    public GameObject stingVolumeSlider;
    public GameObject voiceVolumeSlider;
    public GameObject playerVolumeSlider;
    public GameObject uiVolumeSlider;


    [Header("Load Chapter Menu Images")]
    public GameObject prototypeLevelImage;
    public GameObject levelOneImage;
    public GameObject levelTwoImage;
    public GameObject levelThreeImage;
    public GameObject levelFourImage;

    
    [Header("Pause Menu Buttons Text")]
    public TextMeshProUGUI resumeButtonText;
    public TextMeshProUGUI startNewGameButtonText;
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
    public TextMeshProUGUI PostProcessingText;
    public TextMeshProUGUI BrightnessText;


    [Header("Sound Menu Objects Text")]
    public TextMeshProUGUI musicVolumeSliderText;
    public TextMeshProUGUI ambientVolumeSliderText;
    public TextMeshProUGUI stingVolumeSliderText;
    public TextMeshProUGUI voiceVolumeSliderText;
    public TextMeshProUGUI playerVolumeSliderText;
    public TextMeshProUGUI UIVolumeSliderText;


    [Header("On/Off")]
    public GameObject postProcessingManager;


    //Current Selected Object
    GameObject currentSelected;
    GameObject settingMenuSelected;
    GameObject graphicMenuSelected;
    GameObject loadChapterSelected;
    GameObject soundMenuSelected;


    //Checking If Menu Is On Start Position
    bool pauseMenuBegin = false;
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
    bool pauseMenuInitialNavigationPosition = true;
    bool loadChapterMenuInitialNavigationPosition = true;
    bool settingsMenuInitialNavigationPosition = true;
    bool graphicMenuInitialNavigationPosition = true;
    bool soundMenuInitialNavigationPosition = true;


    //Checking If We Played Sound Once In Main Menu
    bool resumeButtonPlayedOnce = false;
    bool startNewGameButtonPlayedOnce = false;
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
    bool PostProcessingTogglePlayedOnce = false;
    bool BrightnessVolumeSliderPlayedOnce = false;


    //Checking If We Played Sound Once In Sound Menu
    bool musicVolumeSliderPlayedOnce = false;
    bool ambientVolumeSliderPlayedOnce = false;
    bool stingVolumeSliderPlayedOnce = false;
    bool voiceVolumeSliderPlayedOnce = false;
    bool playerVolumeSliderPlayedOnce = false;
    bool UIVolumeSliderPlayedOnce = false;


    //Allow Select Sound
    bool allowSelectSound = true;
    bool backFromSelect = false;
    bool graphicOptionsSelected = false;

    //Avoiding double enter for example entering graphics menu and activating post processing effects in the same time
    bool canSetPostProcessingEffects = false;


    //Disable Mouse
    GameObject lastselect;


    //Load Level
    GameObject currentSelectedLevel;


    //Post Processing
    static public bool postProcessingEnabled = true;


    //Slider
    [Header("Brigtness Slider Objects")]
    public Image sliderBrigtnessBackgroundImage;
    public Image sliderBrigtnessFillAreaImage;
    public Image sliderBrigtnessHandleImage;
    public Image grayFader;


    [Header("FullScreenToggle Objects")]
    public Image fullScreenToggleBackgroundImage;
    public Image fullScreenToggleCheckmarkImage;
    
    
    [Header("PostProcessingToggle Objects")]
    public Image postProcessingToggleBackgroundImage;
    public Image postProcessingToggleCheckmarkImage;


    [Header("QualityDropdown Objects")]
    public Image QualityDropdownImage;


    [Header("ResolutionDropdown Objects")]
    public Image ResolutionDropdownImage;


    //Sliders and variables used to turn off the sound in extreme positions
    public Slider brightnessSlider;
    public Slider musicVolumeSliderReference;
    public Slider ambientVolumeSliderReference;
    public Slider stingVolumeSliderReference;
    public Slider playerVolumeSliderReference;
    public Slider voiceVolumeSliderReference;
    public Slider UIVolumeSliderReference;
    bool sliderBrightnessExtremeValueLeftPlayedOnce = false;
    bool sliderBrightnessExtremeValueRightPlayedOnce = false;
    bool sliderMusicVolumeExtremeValueLeftPlayedOnce = false;
    bool sliderMusicVolumeExtremeValueRightPlayedOnce = false;
    bool sliderAmbientVolumeExtremeValueLeftPlayedOnce = false;
    bool sliderAmbientVolumeExtremeValueRightPlayedOnce = false;
    bool sliderStingVolumeExtremeValueLeftPlayedOnce = false;
    bool sliderStingVolumeExtremeValueRightPlayedOnce = false;
    bool sliderPlayerVolumeExtremeValueLeftPlayedOnce = false;
    bool sliderPlayerVolumeExtremeValueRightPlayedOnce = false;
    bool sliderVoiceVolumeExtremeValueLeftPlayedOnce = false;
    bool sliderVoiceVolumeExtremeValueRightPlayedOnce = false;
    bool sliderUIVolumeExtremeValueLeftPlayedOnce = false;
    bool sliderUIVolumeExtremeValueRightPlayedOnce = false;


    [Header("Music Volume Slider Objects")]
    public Image sliderMusicVolumeBackgroundImage;
    public Image sliderMusicVolumeHandleImage;


    [Header("Ambient Volume Slider Objects")]
    public Image sliderAmbientVolumeBackgroundImage;
    public Image sliderAmbientVolumeHandleImage;


    [Header("Sting Volume Slider Objects")]
    public Image sliderStingVolumeBackgroundImage;
    public Image sliderStingVolumeHandleImage;


    [Header("Player Volume Slider Objects")]
    public Image sliderPlayerVolumeBackgroundImage;
    public Image sliderPlayerVolumeHandleImage;


    [Header("Voice Volume Slider Objects")]
    public Image sliderVoiceVolumeBackgroundImage;
    public Image sliderVoiceVolumeHandleImage;


    [Header("UI Volume Slider Objects")]
    public Image sliderUIVolumeBackgroundImage;
    public Image sliderUIVolumeHandleImage;


    [Header("Camera Damping")]
    public GameObject playerFollowCam;


    [Header("Load/Save")]
    public GameObject fullScreenCheckmark;


    [Header("Player Positions")]
    //SectorNumberZero
    static public float PlayerPositionPrototypeLevelX = -130.68f;
    static public float PlayerPositionPrototypeLevelY = -64.271f;
    static public float PlayerPositionPrototypeLevelZ = 0.0f;
    //SectorNumberOne
    static public float PlayerPositionLevelOneX = 170f;
    static public float PlayerPositionLevelOneY = -107f;
    static public float PlayerPositionLevelOneZ = 0.0f;
    //SectorNumberTwo
    static public float PlayerPositionLevelTwoX = 450f;
    static public float PlayerPositionLevelTwoY = -103f;
    static public float PlayerPositionLevelTwoZ = 0.0f;
    //SectorNumberThree
    static public float PlayerPositionLevelThreeX = 1014f;
    static public float PlayerPositionLevelThreeY = -27f;
    static public float PlayerPositionLevelThreeZ = 0.0f;
    //SectorNumberFour
    static public float PlayerPositionLevelFourX = 1325f;
    static public float PlayerPositionLevelFourY = -36f;
    static public float PlayerPositionLevelFourZ = 0.0f;

    void Start()
    {
        lastselect = new GameObject();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(PlayerPrefs.GetInt("loadLevelPrototypePlayerPosition") == 1)
        {
            LoadPlayerPositionPrototypeLevel();
            PlayerPrefs.SetInt("loadLevelPrototypePlayerPosition", 0);
        }
        else if(PlayerPrefs.GetInt("loadLevelOnePlayerPosition") == 1)
        {
            LoadPlayerPositionLevelOne();
            PlayerPrefs.SetInt("loadLevelOnePlayerPosition", 0);
        }
        else if(PlayerPrefs.GetInt("loadLevelTwoPlayerPosition") == 1)
        {
            LoadPlayerPositionLevelTwo();
            PlayerPrefs.SetInt("loadLevelTwoPlayerPosition", 0);
        }
        else if(PlayerPrefs.GetInt("loadLevelThreePlayerPosition") == 1)
        {
            LoadPlayerPositionLevelThree();
            PlayerPrefs.SetInt("loadLevelThreePlayerPosition", 0);
        }
        else if(PlayerPrefs.GetInt("loadLevelFourPlayerPosition") == 1)
        {
            LoadPlayerPositionLevelFour();
            PlayerPrefs.SetInt("loadLevelFourPlayerPosition", 0);
        }
    }

    void Update()
    {
        try
        {
            if(!PauseMenu.GameIsPaused)
            {
                ResetMenu();
            }

            DisableMouse();
            
            if (pauseMenu.activeSelf == true)
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
                    pauseMenuBegin = true;
                }
                
                if (!pauseMenuBegin && !backFromSettings)
                {
                    SetNewSelectedGameObject();
                    pauseMenuBegin = true;
                }
                else if (pauseMenuBegin)
                {
                    currentSelected = EventSystem.current.currentSelectedGameObject;
                }

                if(currentSelected.name == "ResumeButton")
                {
                    SetDefaultColorForText();
                    SetHightlightColor(resumeButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(resumeButton);
                    
                    //Play only when you changed navigation in menu
                    if(!pauseMenuInitialNavigationPosition && !resumeButtonPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        resumeButtonPlayedOnce = true;
                    }
                    startNewGameButtonPlayedOnce = false;
                    loadChapterButtonPlayedOnce = false;
                    settingsButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "StartNewGameButton")
                {
                    SetDefaultColorForText();
                    SetHightlightColor(startNewGameButtonText);
                    LoadLevel();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(startNewGameButton);

                    //Navigation was changed
                    pauseMenuInitialNavigationPosition = false;
                    //Play audio only once
                    if(!startNewGameButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        startNewGameButtonPlayedOnce = true;
                    }
                    resumeButtonPlayedOnce = false;  
                    settingsButtonPlayedOnce = false;
                    loadChapterButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "LoadChapterButton")
                {
                    SetDefaultColorForText();
                    SetHightlightColor(loadChapterButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(loadChapterButton);

                    //Navigation was changed
                    pauseMenuInitialNavigationPosition = false;
                    //Play audio only once
                    if(!loadChapterButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        loadChapterButtonPlayedOnce = true;
                    }
                    resumeButtonPlayedOnce = false;  
                    startNewGameButtonPlayedOnce = false;
                    settingsButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;
                }
                else if(currentSelected.name == "SettingsButton")
                {
                    SetDefaultColorForText();
                    SetHightlightColor(settingsButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(settingsButton);

                    //Navigation was changed
                    pauseMenuInitialNavigationPosition = false;
                    //Play audio only once
                    if(!settingsButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();  
                        settingsButtonPlayedOnce = true;
                    }
                    resumeButtonPlayedOnce = false;
                    startNewGameButtonPlayedOnce = false;
                    loadChapterButtonPlayedOnce = false;
                    exitButtonPlayedOnce = false;  
                }
                else if(currentSelected.name == "ExitButton")
                {
                    SetDefaultColorForText();
                    SetHightlightColor(exitButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(exitButton);

                    //Navigation was changed
                    pauseMenuInitialNavigationPosition = false;
                    //Play audio only once
                    if(!exitButtonPlayedOnce)
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();  
                        exitButtonPlayedOnce = true;
                    }
                    resumeButtonPlayedOnce = false;
                    startNewGameButtonPlayedOnce = false;
                    loadChapterButtonPlayedOnce = false;
                    settingsButtonPlayedOnce = false;
                }
            }
            else if (settingMenu.activeSelf == true)
            {
                PauseMenu.canBackToGame = false;
                canSetPostProcessingEffects = false;
                
                PlayBackSound();
                
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
                    SetDefaultColorForText();
                    SetHightlightColor(controlsButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(controlsButton);

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
                    SetDefaultColorForText();
                    SetHightlightColor(graphicButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(graphicButton);

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
                    SetDefaultColorForText();
                    SetHightlightColor(soundButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(soundButton);

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
                    SetDefaultColorForText();
                    SetHightlightColor(creditsButtonText);
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(creditsButton);

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
                PlayBackSound();
                graphicOptionsSelected = false;

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
                    grayFader.enabled = true;
                    if(Input.GetKeyDown(KeyCode.Return) && !graphicOptionsSelected)
                    {
                        AudioManager.PlaySelectMenuNavigationAudio();
                        graphicOptionsSelected = true;
                    }
                    SetDefaultColorForText();
                    SetHightlightColor(qualityDropdownText);
                    SetDefaultColorForImage();
                    SetDefaultColorForToggle();
                    SetDefaultColorForDropdown();
                    ChangeQualityDropdownColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(qualityDropdown);

                    //Play only when you changed navigation in menu
                    if(!graphicMenuInitialNavigationPosition && !qualityDropdownPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        qualityDropdownPlayedOnce = true;
                    }
                    resolutionDropdownPlayedOnce = false;
                    fullScreenTogglePlayedOnce = false;
                    PostProcessingTogglePlayedOnce = false;
                    BrightnessVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "ResolutionDropdown")
                {
                    grayFader.enabled = true;
                    if(Input.GetKeyDown(KeyCode.Return) && !graphicOptionsSelected)
                    {
                        AudioManager.PlaySelectMenuNavigationAudio();
                        graphicOptionsSelected = true;
                    }
                    SetDefaultColorForText();
                    SetHightlightColor(resolutionDropdownText);
                    SetDefaultColorForImage();
                    SetDefaultColorForToggle();
                    SetDefaultColorForDropdown();
                    ChangeResolutionDropdownColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(resolutionDropdown);

                    graphicMenuInitialNavigationPosition = false;
                    if(!graphicMenuInitialNavigationPosition && !resolutionDropdownPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        resolutionDropdownPlayedOnce = true;
                    }
                    qualityDropdownPlayedOnce = false;
                    fullScreenTogglePlayedOnce = false;
                    PostProcessingTogglePlayedOnce = false;
                    BrightnessVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "FullScreenToggle")
                {
                    grayFader.enabled = true;
                    if(Input.GetKeyDown(KeyCode.Return) && !graphicOptionsSelected)
                    {
                        AudioManager.PlaySelectMenuNavigationAudio();
                        graphicOptionsSelected = true;
                    }
                    SetDefaultColorForText();
                    SetHightlightColor(fullScreenToggleText);
                    SetDefaultColorForImage();
                    SetDefaultColorForToggle();
                    ChangeFullScreenToggleColor();
                    SetDefaultColorForDropdown();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(fullScreenToggle);

                    graphicMenuInitialNavigationPosition = false;
                    if(!graphicMenuInitialNavigationPosition && !fullScreenTogglePlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        fullScreenTogglePlayedOnce = true;
                    }
                    qualityDropdownPlayedOnce = false;
                    resolutionDropdownPlayedOnce = false;
                    PostProcessingTogglePlayedOnce = false;
                    BrightnessVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "PostProcessingToggle")
                {
                    grayFader.enabled = true;
                    if(Input.GetKeyDown(KeyCode.Return) && !graphicOptionsSelected && canSetPostProcessingEffects)
                    {
                        AudioManager.PlaySelectMenuNavigationAudio();
                        graphicOptionsSelected = true;
                    }
                    SetDefaultColorForText();
                    SetHightlightColor(PostProcessingText);
                    SetDefaultColorForImage();
                    SetDefaultColorForToggle();
                    ChangePostProcessingToggleColor();
                    SetDefaultColorForDropdown();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(postProcessingToggle);

                    graphicMenuInitialNavigationPosition = false;
                    if(!graphicMenuInitialNavigationPosition && !PostProcessingTogglePlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        PostProcessingTogglePlayedOnce = true;
                    }
                    qualityDropdownPlayedOnce = false;
                    resolutionDropdownPlayedOnce = false;
                    fullScreenTogglePlayedOnce = false;
                    BrightnessVolumeSliderPlayedOnce = false;

                    if(Input.GetKeyDown(KeyCode.Return) && postProcessingEnabled && canSetPostProcessingEffects)
                    {
                        SetPostProcessing(false);
                    }
                    else if(Input.GetKeyDown(KeyCode.Return) && !postProcessingEnabled & canSetPostProcessingEffects)
                    {
                        SetPostProcessing(true);
                    }
                }
                else if(currentSelected.name == "BrightnessVolumeSlider")
                {
                    grayFader.enabled = false;
                    sliderBrightnessExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(brightnessSlider, sliderBrightnessExtremeValueLeftPlayedOnce);
                    sliderBrightnessExtremeValueRightPlayedOnce = CheckExtremeRightPosition(brightnessSlider, sliderBrightnessExtremeValueRightPlayedOnce);
                    
                    if(sliderBrightnessExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderBrightnessExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderBrightnessExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderBrightnessExtremeValueRightPlayedOnce = false;
                    }
                    
                    if(Input.GetKeyDown(KeyCode.Return) && !graphicOptionsSelected)
                    {
                        AudioManager.PlaySelectMenuNavigationAudio();
                        graphicOptionsSelected = true;
                    }
                    SetDefaultColorForText();
                    SetHightlightColor(BrightnessText);
                    ChangeBrightnessSliderColor();
                    SetDefaultColorForToggle();
                    SetDefaultColorForDropdown();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(brightnessVolumeSlider);

                    graphicMenuInitialNavigationPosition = false;
                    if(!graphicMenuInitialNavigationPosition && !BrightnessVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        BrightnessVolumeSliderPlayedOnce = true;
                    }
                    qualityDropdownPlayedOnce = false;
                    resolutionDropdownPlayedOnce = false;
                    fullScreenTogglePlayedOnce = false;
                    PostProcessingTogglePlayedOnce = false;
                }
                //Catching enter button to avoid unwated enter to postprocessing option
                if(Input.GetKeyDown(KeyCode.Return) && !canSetPostProcessingEffects)
                {
                    canSetPostProcessingEffects = true;
                }
            }
            else if (soundMenu.activeSelf == true)
            {
                PlayBackSound();
                
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                    backFromSelect = true;
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
                    sliderMusicVolumeExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(musicVolumeSliderReference, sliderMusicVolumeExtremeValueLeftPlayedOnce);
                    sliderMusicVolumeExtremeValueRightPlayedOnce = CheckExtremeRightPosition(musicVolumeSliderReference, sliderMusicVolumeExtremeValueRightPlayedOnce);
                    
                    if(sliderMusicVolumeExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderMusicVolumeExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderMusicVolumeExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderMusicVolumeExtremeValueRightPlayedOnce = false;
                    }

                    SetDefaultColorForText();
                    SetHightlightColor(musicVolumeSliderText);
                    SetDefaultColorForSlider();
                    ChangeMusicVolumeSliderColor();
                    SetDefaultColorForDropdown();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(musicVolumeSlider);

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
                    UIVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "AmbientVolumeSlider")
                {
                    sliderAmbientVolumeExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(ambientVolumeSliderReference, sliderAmbientVolumeExtremeValueLeftPlayedOnce);
                    sliderAmbientVolumeExtremeValueRightPlayedOnce = CheckExtremeRightPosition(ambientVolumeSliderReference, sliderAmbientVolumeExtremeValueRightPlayedOnce);
                    
                    if(sliderAmbientVolumeExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderAmbientVolumeExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderAmbientVolumeExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderAmbientVolumeExtremeValueRightPlayedOnce = false;
                    }

                    SetDefaultColorForText();
                    SetHightlightColor(ambientVolumeSliderText);
                    SetDefaultColorForSlider();
                    ChangeAmbientVolumeSliderColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(ambientVolumeSlider);

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
                    UIVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "StingVolumeSlider")
                {
                    sliderStingVolumeExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(stingVolumeSliderReference, sliderStingVolumeExtremeValueLeftPlayedOnce);
                    sliderStingVolumeExtremeValueRightPlayedOnce = CheckExtremeRightPosition(stingVolumeSliderReference, sliderStingVolumeExtremeValueRightPlayedOnce);
                    
                    if(sliderStingVolumeExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderStingVolumeExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderStingVolumeExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderStingVolumeExtremeValueRightPlayedOnce = false;
                    }

                    SetDefaultColorForText();
                    SetHightlightColor(stingVolumeSliderText);
                    SetDefaultColorForSlider();
                    ChangeStingVolumeSliderColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(stingVolumeSlider);

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
                    UIVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "VoiceVolumeSlider")
                {
                    sliderVoiceVolumeExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(voiceVolumeSliderReference, sliderVoiceVolumeExtremeValueLeftPlayedOnce);
                    sliderVoiceVolumeExtremeValueRightPlayedOnce = CheckExtremeRightPosition(voiceVolumeSliderReference, sliderVoiceVolumeExtremeValueRightPlayedOnce);
                    
                    if(sliderVoiceVolumeExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderVoiceVolumeExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderVoiceVolumeExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderVoiceVolumeExtremeValueRightPlayedOnce = false;
                    }

                    SetDefaultColorForText();
                    SetHightlightColor(voiceVolumeSliderText);
                    SetDefaultColorForSlider();
                    ChangeVoiceVolumeSliderColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(voiceVolumeSlider);

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
                    UIVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "PlayerVolumeSlider")
                {
                    sliderPlayerVolumeExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(playerVolumeSliderReference, sliderPlayerVolumeExtremeValueLeftPlayedOnce);
                    sliderPlayerVolumeExtremeValueRightPlayedOnce = CheckExtremeRightPosition(playerVolumeSliderReference, sliderPlayerVolumeExtremeValueRightPlayedOnce);
                    
                    if(sliderPlayerVolumeExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderPlayerVolumeExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderPlayerVolumeExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderPlayerVolumeExtremeValueRightPlayedOnce = false;
                    }

                    SetDefaultColorForText();
                    SetHightlightColor(playerVolumeSliderText);
                    SetDefaultColorForSlider();
                    ChangePlayerVolumeSliderColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(playerVolumeSlider);

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
                    UIVolumeSliderPlayedOnce = false;
                }
                else if(currentSelected.name == "UIVolumeSlider")
                {
                    sliderUIVolumeExtremeValueLeftPlayedOnce = CheckExtremeLeftPosition(UIVolumeSliderReference, sliderUIVolumeExtremeValueLeftPlayedOnce);
                    sliderUIVolumeExtremeValueRightPlayedOnce = CheckExtremeRightPosition(UIVolumeSliderReference, sliderUIVolumeExtremeValueRightPlayedOnce);
                    
                    if(sliderUIVolumeExtremeValueLeftPlayedOnce && Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        sliderUIVolumeExtremeValueLeftPlayedOnce = false;
                    }
                    else if(sliderUIVolumeExtremeValueRightPlayedOnce && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        sliderUIVolumeExtremeValueRightPlayedOnce = false;
                    }

                    SetDefaultColorForText();
                    SetHightlightColor(UIVolumeSliderText);
                    SetDefaultColorForSlider();
                    ChangeUIVolumeSliderColor();
                    //Setting default button size
                    SetDefaultButtonSize();
                    //Button is selected so we can enlarge size
                    EnlargeSizeOfButton(uiVolumeSlider);

                    soundMenuInitialNavigationPosition = false;
                    if(!soundMenuInitialNavigationPosition && !UIVolumeSliderPlayedOnce) 
                    {
                        AudioManager.PlayUpDownMenuNavigationAudio();
                        UIVolumeSliderPlayedOnce = true;
                    }
                    musicVolumeSliderPlayedOnce = false;
                    ambientVolumeSliderPlayedOnce = false;
                    stingVolumeSliderPlayedOnce = false;
                    voiceVolumeSliderPlayedOnce = false;
                    playerVolumeSliderPlayedOnce = false;
                }
            }
            else if (loadChapterMenu.activeSelf == true)
            {
                PauseMenu.canBackToGame = false;
                
                PlayBackSound();
                LoadLevel();
                
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
                    DisableAllImages();
                    EnableImage(prototypeLevelImage);
                    
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
                    DisableAllImages();
                    EnableImage(levelOneImage);
                    
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
                    DisableAllImages();
                    EnableImage(levelTwoImage);
                    
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
                    DisableAllImages();
                    EnableImage(levelThreeImage);
                    
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
                    DisableAllImages();
                    EnableImage(levelFourImage);
                    
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
                PlayBackSound();
                
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                    backFromSelect = true;
                }
                if (!loadChapterMenuBegin)
                {
                    SetNewSelectedGameObject();
                }
            }
            else if (creditsMenu.activeSelf)
            {
                PlayBackSound();
                
                if(!allowSelectSound)
                {
                    AudioManager.PlaySelectMenuNavigationAudio();
                    allowSelectSound = true;
                    backFromSelect = true;
                }
                if (loadChapterMenuBegin)
                {
                    SetNewSelectedGameObject();
                }
            }
        }
        catch (NullReferenceException) {}
    }

    void SetNewSelectedGameObject()
    {
        if (pauseMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = pauseMenuFirstSelectedButton;
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
        else if(controlsMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = controlsButton;
        }
        else if(creditsMenu.activeSelf)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = creditsButton;
        }
        EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
    }

    void SetDefaultColorForText()
    {
        if(pauseMenu.activeSelf)
        {
            resumeButtonText.color = new Color32(100, 100, 100, 255);
            startNewGameButtonText.color = new Color32(100, 100, 100, 255);
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
            PostProcessingText.color = new Color32(100, 100, 100, 255);
            BrightnessText.color = new Color32(100, 100, 100, 255);
        }
        else if(soundMenu.activeSelf)
        {
            musicVolumeSliderText.color = new Color32(100, 100, 100, 255);
            ambientVolumeSliderText.color = new Color32(100, 100, 100, 255);
            stingVolumeSliderText.color = new Color32(100, 100, 100, 255);
            voiceVolumeSliderText.color = new Color32(100, 100, 100, 255);
            playerVolumeSliderText.color = new Color32(100, 100, 100, 255);
            UIVolumeSliderText.color = new Color32(100, 100, 100, 255);
        }
    }

    void SetHightlightColor(TextMeshProUGUI objectToHighlight)
    {
        objectToHighlight.color = new Color32(255, 255, 255, 255);
    }

    void DisableAllImages()
    {
        prototypeLevelImage.SetActive(false);
        levelOneImage.SetActive(false);
        levelTwoImage.SetActive(false);
        levelThreeImage.SetActive(false);
        levelFourImage.SetActive(false);
    }

    void EnableImage(GameObject image)
    {
        image.SetActive(true);
    }

    void PlayBackSound()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Main Menu
            if (settingMenu.activeSelf == true)
            {
                pauseMenu.SetActive(true);
                settingMenu.SetActive(false);
                AudioManager.PlayBackFromMenuNavigationAudio();
            }

            //Settings Options
            if (controlsMenu.activeSelf == true)
            {
                settingMenu.SetActive(true);
                controlsMenu.SetActive(false);
                AudioManager.PlayBackFromMenuNavigationAudio();
            }
            if (graphicMenu.activeSelf == true)
            {
                settingMenu.SetActive(true);
                graphicMenu.SetActive(false);
                AudioManager.PlayBackFromMenuNavigationAudio();
            }
            if (soundMenu.activeSelf == true)
            {
                settingMenu.SetActive(true);
                soundMenu.SetActive(false);
                AudioManager.PlayBackFromMenuNavigationAudio();
            }
            if (creditsMenu.activeSelf == true)
            {
                settingMenu.SetActive(true);
                creditsMenu.SetActive(false);
                AudioManager.PlayBackFromMenuNavigationAudio();
            }
            
            //LoadChapterMenuScenes
            if (loadChapterMenu.activeSelf == true)
            {
                pauseMenu.SetActive(true);
                loadChapterMenu.SetActive(false);
                AudioManager.PlayBackFromMenuNavigationAudio();
            }
        }
    }

    void DisableMouse()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void LoadLevel()
    {
        if (Input.GetKeyDown("return"))
        {
            currentSelectedLevel = EventSystem.current.currentSelectedGameObject;
            if(currentSelectedLevel.name == "PrototypeLevel")
            {
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 0);
                PlayerPrefs.SetInt("loadLevelPrototypePlayerPosition", 1);
                SceneManager.LoadScene("PrototypeScene");
            }
            else if(currentSelectedLevel.name == "LevelOne")
            {
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 1);
                PlayerPrefs.SetInt("loadLevelOnePlayerPosition", 1);
                SceneManager.LoadScene("PrototypeScene");
            }
            else if(currentSelectedLevel.name == "LevelTwo")
            {
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 2);
                PlayerPrefs.SetInt("loadLevelTwoPlayerPosition", 1);
                SceneManager.LoadScene("PrototypeScene");
            }
            else if(currentSelectedLevel.name == "LevelThree")
            {
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 3);
                PlayerPrefs.SetInt("loadLevelThreePlayerPosition", 1);
                SceneManager.LoadScene("PrototypeScene");
            }
            else if(currentSelectedLevel.name == "LevelFour")
            {
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 4);
                PlayerPrefs.SetInt("loadLevelFourPlayerPosition", 1);
                SceneManager.LoadScene("PrototypeScene");
            }
            else if(currentSelected.name == "StartNewGameButton")
            {
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("TheHighestLevelReachedByThePlayer", 0);
                PlayerPrefs.SetInt("loadLevelPrototypePlayerPosition", 1);
                SceneManager.LoadScene("PrototypeScene");
                GameManager.ClearOrbs();
            }
        }
    }

    public void SetPostProcessing (bool isTurnedOn)
    {
        postProcessingManager.SetActive(isTurnedOn);
        postProcessingEnabled = isTurnedOn;
    }

    public void ChangeBrightnessSliderColor()
    {
        sliderBrigtnessBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderBrigtnessFillAreaImage.color = new Color32(255, 255, 255, 255);
        sliderBrigtnessHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void SetDefaultColorForImage()
    {
        sliderBrigtnessBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderBrigtnessFillAreaImage.color = new Color32(100, 100, 100, 255);
        sliderBrigtnessHandleImage.color = new Color32(100, 100, 100, 255);
    }

    public void ChangeFullScreenToggleColor()
    {
        fullScreenToggleBackgroundImage.color = new Color32(255, 255, 255, 255);
        fullScreenToggleCheckmarkImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangePostProcessingToggleColor()
    {
        postProcessingToggleBackgroundImage.color = new Color32(255, 255, 255, 255);
        postProcessingToggleCheckmarkImage.color = new Color32(255, 255, 255, 255);
    }

    public void SetDefaultColorForToggle()
    {
        postProcessingToggleBackgroundImage.color = new Color32(100, 100, 100, 255);
        postProcessingToggleCheckmarkImage.color = new Color32(100, 100, 100, 255);
        fullScreenToggleBackgroundImage.color = new Color32(100, 100, 100, 255);
        fullScreenToggleCheckmarkImage.color = new Color32(100, 100, 100, 255);
    }

    public void ChangeQualityDropdownColor()
    {
        QualityDropdownImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangeResolutionDropdownColor()
    {
        ResolutionDropdownImage.color = new Color32(255, 255, 255, 255);
    }

    public void SetDefaultColorForDropdown()
    {
        QualityDropdownImage.color = new Color32(100, 100, 100, 255);
        ResolutionDropdownImage.color = new Color32(100, 100, 100, 255);
    }

    public void ChangeMusicVolumeSliderColor()
    {
        sliderMusicVolumeBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderMusicVolumeHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangeAmbientVolumeSliderColor()
    {
        sliderAmbientVolumeBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderAmbientVolumeHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangeStingVolumeSliderColor()
    {
        sliderStingVolumeBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderStingVolumeHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangePlayerVolumeSliderColor()
    {
        sliderPlayerVolumeBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderPlayerVolumeHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangeVoiceVolumeSliderColor()
    {
        sliderVoiceVolumeBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderVoiceVolumeHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void ChangeUIVolumeSliderColor()
    {
        sliderUIVolumeBackgroundImage.color = new Color32(255, 255, 255, 255);
        sliderUIVolumeHandleImage.color = new Color32(255, 255, 255, 255);
    }

    public void SetDefaultColorForSlider()
    {
        sliderMusicVolumeBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderMusicVolumeHandleImage.color = new Color32(100, 100, 100, 255);
        sliderAmbientVolumeBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderAmbientVolumeHandleImage.color = new Color32(100, 100, 100, 255);
        sliderStingVolumeBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderStingVolumeHandleImage.color = new Color32(100, 100, 100, 255);
        sliderPlayerVolumeBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderPlayerVolumeHandleImage.color = new Color32(100, 100, 100, 255);
        sliderVoiceVolumeBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderVoiceVolumeHandleImage.color = new Color32(100, 100, 100, 255);
        sliderUIVolumeBackgroundImage.color = new Color32(100, 100, 100, 255);
        sliderUIVolumeHandleImage.color = new Color32(100, 100, 100, 255);
    }

    public bool CheckExtremeLeftPosition(Slider referenceToSlider, bool leftExtreme)
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(referenceToSlider.value >= referenceToSlider.minValue)
            {
                if(referenceToSlider.value == referenceToSlider.minValue && !leftExtreme)
                {
                    AudioManager.PlayLeftRightMenuNavigationAudio();
                    leftExtreme = true;
                }
                else if(!leftExtreme)
                {
                    AudioManager.PlayLeftRightMenuNavigationAudio();
                }
            }
        }
        return leftExtreme;
    }

    public bool CheckExtremeRightPosition(Slider referenceToSlider, bool rightExtreme)
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(referenceToSlider.value <= referenceToSlider.maxValue)
            {
                if(referenceToSlider.value == referenceToSlider.maxValue && !rightExtreme)
                {
                    AudioManager.PlayLeftRightMenuNavigationAudio();
                    rightExtreme = true;
                }
                else if(!rightExtreme)
                {
                    AudioManager.PlayLeftRightMenuNavigationAudio();
                }
            }
        }
        return rightExtreme;
    }

    public void ResetMenu()
    {
        pauseMenuBegin = false;
        settingMenuBegin = false;
        graphicMenuBegin = false;
        soundMenuBegin = false;
        loadChapterMenuBegin = false;
        backFromSettings = false;
        backFromGraphic = false;
        backFromLoadChapter = false;
        backFromSound = false;
        pauseMenuInitialNavigationPosition = true;
        loadChapterMenuInitialNavigationPosition = true;
        settingsMenuInitialNavigationPosition = true;
        graphicMenuInitialNavigationPosition = true;
        soundMenuInitialNavigationPosition = true;
        resumeButtonPlayedOnce = false;
        startNewGameButtonPlayedOnce = false;
        loadChapterButtonPlayedOnce = false;
        settingsButtonPlayedOnce = false;
        exitButtonPlayedOnce = false;
        prototypeLevelPlayedOnce = true;
        levelOnePlayedOnce = false;
        levelTwoPlayedOnce = false;
        levelThreePlayedOnce = false;
        levelFourPlayedOnce = false;
        controlsButtonPlayedOnce = false;
        graphicButtonPlayedOnce = false;
        soundButtonPlayedOnce = false;
        creditsButtonPlayedOnce = false;
        qualityDropdownPlayedOnce = false;
        resolutionDropdownPlayedOnce = false;
        fullScreenTogglePlayedOnce = false;
        PostProcessingTogglePlayedOnce = false;
        BrightnessVolumeSliderPlayedOnce = false;
        musicVolumeSliderPlayedOnce = false;
        ambientVolumeSliderPlayedOnce = false;
        stingVolumeSliderPlayedOnce = false;
        voiceVolumeSliderPlayedOnce = false;
        playerVolumeSliderPlayedOnce = false;
        UIVolumeSliderPlayedOnce = false;
        allowSelectSound = true;
        backFromSelect = false;
        graphicOptionsSelected = false;
        resumeButtonText.color = new Color32(100, 100, 100, 255);
        startNewGameButtonText.color = new Color32(100, 100, 100, 255);
        loadChapterButtonText.color = new Color32(100, 100, 100, 255);
        settingsButtonText.color = new Color32(100, 100, 100, 255);
        exitButtonText.color = new Color32(100, 100, 100, 255);
        currentSelected = pauseMenuFirstSelectedButton;
    }

    static public void LoadPlayerPositionPrototypeLevel()
    {
        GameObject.Find("Robbie").transform.position = new Vector3(PlayerPositionPrototypeLevelX, PlayerPositionPrototypeLevelY, PlayerPositionPrototypeLevelZ);
    }
    
    static public void LoadPlayerPositionLevelOne()
    {
        GameObject.Find("Robbie").transform.position = new Vector3(PlayerPositionLevelOneX, PlayerPositionLevelOneY, PlayerPositionLevelOneZ);
    }
    
    static public void LoadPlayerPositionLevelTwo()
    {
        GameObject.Find("Robbie").transform.position = new Vector3(PlayerPositionLevelTwoX, PlayerPositionLevelTwoY, PlayerPositionLevelTwoZ);
    }

    static public void LoadPlayerPositionLevelThree()
    {
        GameObject.Find("Robbie").transform.position = new Vector3(PlayerPositionLevelThreeX, PlayerPositionLevelThreeY, PlayerPositionLevelThreeZ);
    }

    static public void LoadPlayerPositionLevelFour()
    {
        GameObject.Find("Robbie").transform.position = new Vector3(PlayerPositionLevelFourX, PlayerPositionLevelFourY, PlayerPositionLevelFourZ);
    }

    public void DisableVirtualPlayerCameraDamping()
    {
        playerFollowCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0;
        playerFollowCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 0;
        playerFollowCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ZDamping = 0;
    }

    public void EnableVirtualPlayerCameraDamping()
    {
        playerFollowCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 1;
        playerFollowCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 1;
        playerFollowCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ZDamping = 1;
    }

    public void EnlargeSizeOfButton(GameObject Button)
    {
        Button.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
    }

    public void SetDefaultButtonSize()
    {
        if(pauseMenu.activeSelf == true)
        {
            resumeButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            startNewGameButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            loadChapterButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            settingsButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            exitButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if(settingMenu.activeSelf == true)
        {
            controlsButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            graphicButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            soundButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            creditsButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if(graphicMenu.activeSelf == true)
        {
            qualityDropdown.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            resolutionDropdown.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            fullScreenToggle.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            postProcessingToggle.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            brightnessVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if(soundMenu.activeSelf == true)
        {
            musicVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            ambientVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            stingVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            voiceVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            playerVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            uiVolumeSlider.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}