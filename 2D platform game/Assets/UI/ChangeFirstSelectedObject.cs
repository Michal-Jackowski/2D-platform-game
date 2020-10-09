using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeFirstSelectedObject : MonoBehaviour
{
    public GameObject settingMenuFirstSelectedButton; 
    public GameObject mainMenuFirstSelectedButton;
    public GameObject settingMenu;
    public GameObject mainMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (mainMenu.activeSelf == true)
        {
            //Debug.Log("FirstSelectedButton = playButton");
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = mainMenuFirstSelectedButton;
        }
        else if (settingMenu.activeSelf == true)
        {
            //Debug.Log("FirstSelectedButton = controlsButton");
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuFirstSelectedButton;
        }
    }
}
