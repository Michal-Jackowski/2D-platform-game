using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChangeColorText : MonoBehaviour
{
    //Menu scenes
    public GameObject settingMenu;
    public GameObject mainMenu;

    //Menu firstSelectedObjects
    public GameObject settingMenuFirstSelectedButton; 
    public GameObject mainMenuFirstSelectedButton;
    
    //MainMenu buttons
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI LoadChapterButtonText;
    public TextMeshProUGUI SettingsButtonText;
    public TextMeshProUGUI ExitButtonText;
    
    //SettingsMenu buttons
    public TextMeshProUGUI ControlsButton;
    public TextMeshProUGUI GraphicButton;
    public TextMeshProUGUI SoundButton;
    public TextMeshProUGUI CreditsButton;

    GameObject currentSelected;

    bool settingMenuBegin = false;
    bool mainMenuBegin = false;
    bool firstSelectedGameObjectReady = false;
    
    // Update is called once per frame
    void Update()
    {
        //MainMenu
        if (mainMenu.activeSelf == true)
        {
            settingMenuBegin = false;

            if (!mainMenuBegin)
            {
                ChangeFirstSelectedObject();
                EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                mainMenuBegin = true;
                firstSelectedGameObjectReady = true;
            }
            else if (mainMenuBegin && firstSelectedGameObjectReady)
            {
                currentSelected = EventSystem.current.currentSelectedGameObject;
            }
            
            if(firstSelectedGameObjectReady && currentSelected.name == "PlayButton")
            {
                PlayButtonText.color = new Color32(255, 255, 255, 255);
                LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                ExitButtonText.color = new Color32(100, 100, 100, 255);
            }
            else if(firstSelectedGameObjectReady && currentSelected.name == "LoadChapterButton")
            {
                LoadChapterButtonText.color = new Color32(255, 255, 255, 255);
                PlayButtonText.color = new Color32(100, 100, 100, 255);
                SettingsButtonText.color = new Color32(100, 100, 100, 255);
            }
            else if(firstSelectedGameObjectReady && currentSelected.name == "SettingsButton")
            {
                SettingsButtonText.color = new Color32(255, 255, 255, 255);
                LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                ExitButtonText.color = new Color32(100, 100, 100, 255);
            }
            else if(firstSelectedGameObjectReady && currentSelected.name == "ExitButton")
            {
                ExitButtonText.color = new Color32(255, 255, 255, 255);
                PlayButtonText.color = new Color32(100, 100, 100, 255);
                SettingsButtonText.color = new Color32(100, 100, 100, 255);
            }
            else
            {
                Debug.Log("Another state mainMenu");
            }
        }
        //SettingsMenu
        else if (settingMenu.activeSelf == true)
        {
            mainMenuBegin = false;

            if (!settingMenuBegin)
            {
                ChangeFirstSelectedObject();
                EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
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
                CreditsButton.color = new Color32(100, 100, 100, 255);
            }
            else if(currentSelected.name == "GraphicButton")
            {
                GraphicButton.color = new Color32(255, 255, 255, 255);
                ControlsButton.color = new Color32(100, 100, 100, 255);
                SoundButton.color = new Color32(100, 100, 100, 255);
            }
            else if(currentSelected.name == "SoundButton")
            {
                SoundButton.color = new Color32(255, 255, 255, 255);
                GraphicButton.color = new Color32(100, 100, 100, 255);
                CreditsButton.color = new Color32(100, 100, 100, 255);
            }
            else if(currentSelected.name == "CreditsButton")
            {
                CreditsButton.color = new Color32(255, 255, 255, 255);
                ControlsButton.color = new Color32(100, 100, 100, 255);
                SoundButton.color = new Color32(100, 100, 100, 255);
            }
            else
            {
                Debug.Log("Another state settingMenu");
            }
        }
    }

    void ChangeFirstSelectedObject()
    {
        if (mainMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = mainMenuFirstSelectedButton;
        }
        else if (settingMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuFirstSelectedButton;
        }
    }
}