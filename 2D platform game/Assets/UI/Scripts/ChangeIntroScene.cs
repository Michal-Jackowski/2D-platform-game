using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeIntroScene : MonoBehaviour
{
    public GameObject sceneToLoad;
    public GameObject sceneToDisable;
    GameObject currentSelected;
    void Update()
    {
        if(sceneToDisable.activeSelf)
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
                {
                    return;
                }
                else
                {
                    sceneToLoad.SetActive(true);
                    sceneToDisable.SetActive(false);
                    AudioManager.PlaySelectMenuNavigationAudio();
                }
            }
        }
    }
}
