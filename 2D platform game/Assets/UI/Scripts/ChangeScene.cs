using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject firstScene;
    public GameObject secondScene;
    
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                return;
            }
            else
            {
                firstScene.SetActive(true);
                secondScene.SetActive(false);
                AudioManager.PlaySelectMenuNavigationAudio();
            }
        }
    }
}
