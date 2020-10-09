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
    bool begin = false;
    //EventSystem m_EventSystem;
    
    // Update is called once per frame
    void Update()
    {
        //MainMenu
        if (mainMenu.activeSelf == true)
        {
            currentSelected = EventSystem.current.currentSelectedGameObject;
            //Debug.Log(currentSelected);
            
            if(currentSelected.name == "PlayButton")
            {
                PlayButtonText.color = new Color32(255, 255, 255, 255);
                LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                ExitButtonText.color = new Color32(100, 100, 100, 255);
            }
            else if(currentSelected.name == "LoadChapterButton")
            {
                LoadChapterButtonText.color = new Color32(255, 255, 255, 255);
                PlayButtonText.color = new Color32(100, 100, 100, 255);
                SettingsButtonText.color = new Color32(100, 100, 100, 255);
            }
            else if(currentSelected.name == "SettingsButton")
            {
                SettingsButtonText.color = new Color32(255, 255, 255, 255);
                LoadChapterButtonText.color = new Color32(100, 100, 100, 255);
                ExitButtonText.color = new Color32(100, 100, 100, 255);
            }
            else if(currentSelected.name == "ExitButton")
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
            if (!begin)
            {
                EventSystem.current.SetSelectedGameObject(EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject);
                begin = true;
            }
            else
            {
                currentSelected = EventSystem.current.currentSelectedGameObject;
            }
            //Debug.Log(currentSelected);
            
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
}
