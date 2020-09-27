using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject introMenuUI;
    public GameObject startMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            startMenuUI.SetActive(true);
            introMenuUI.SetActive(false);
        }
    }
}
