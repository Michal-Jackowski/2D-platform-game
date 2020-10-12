using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFunction : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.activeSelf == true)
            {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }
        }
    }
}
