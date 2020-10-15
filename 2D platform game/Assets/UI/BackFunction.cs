using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFunction : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject controlsMenu;
    public GameObject graphicMenu;
    public GameObject soundMenu;
    public GameObject creditsMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Main Menu
            if (settingsMenu.activeSelf == true)
            {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }

            //Settings Options
            if (controlsMenu.activeSelf == true)
            {
                settingsMenu.SetActive(true);
                controlsMenu.SetActive(false);
            }
            if (graphicMenu.activeSelf == true)
            {
                settingsMenu.SetActive(true);
                graphicMenu.SetActive(false);
            }
            if (soundMenu.activeSelf == true)
            {
                settingsMenu.SetActive(true);
                soundMenu.SetActive(false);
            }
            if (creditsMenu.activeSelf == true)
            {
                settingsMenu.SetActive(true);
                creditsMenu.SetActive(false);
            }
        }
    }
}
