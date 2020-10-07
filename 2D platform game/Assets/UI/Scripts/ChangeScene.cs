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
            firstScene.SetActive(true);
            secondScene.SetActive(false);
        }
    }
}
