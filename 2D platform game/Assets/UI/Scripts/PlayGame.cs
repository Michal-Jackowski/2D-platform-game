using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject loadChapterMenu0;
    public GameObject loadChapterMenu1;
    public GameObject loadChapterMenu2;
    public GameObject loadChapterMenu3;
    public GameObject loadChapterMenu4;
    
    void Update()
    {
        if (loadChapterMenu0.activeSelf == true || loadChapterMenu1.activeSelf == true || loadChapterMenu2.activeSelf == true|| loadChapterMenu3.activeSelf == true || loadChapterMenu4.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                SceneManager.LoadScene("PrototypeScene");
            }
        }
    }
}
