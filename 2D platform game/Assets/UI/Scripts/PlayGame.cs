using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayGame : MonoBehaviour
{
    public GameObject loadChapterMenu;
    GameObject currentSelected;
    
    void Update()
    {
        if (loadChapterMenu.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                currentSelected = EventSystem.current.currentSelectedGameObject;
                if(currentSelected.name == "PrototypeLevel")
                {
                    SceneManager.LoadScene("PrototypeScene");
                }
                else if(currentSelected.name == "LevelOne")
                {
                    Debug.Log("Load Level One...");
                }
                else if(currentSelected.name == "LevelTwo")
                {
                    Debug.Log("Load Level Two...");
                }
                else if(currentSelected.name == "LevelThree")
                {
                    Debug.Log("Load Level Three...");
                }
                else if(currentSelected.name == "LevelFour")
                {
                    Debug.Log("Load Level Four...");
                }
            }
        }
    }
}
