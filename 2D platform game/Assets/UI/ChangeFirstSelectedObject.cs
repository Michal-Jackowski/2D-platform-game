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
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = mainMenuFirstSelectedButton;
        }
        else if (settingMenu.activeSelf == true)
        {
            EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = settingMenuFirstSelectedButton;
        }
    }
}
