using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering;

public class SetPostProcessing : MonoBehaviour
{
    public UnityEngine.Rendering.PostProcessing.PostProcessVolume volumeProfile;
    public UnityEngine.Rendering.PostProcessing.Vignette vignette;
    public GameObject introMenu;
    
    void Update()
    {
        //default 0.602
        if(introMenu.activeSelf)
        {
            vignette.intensity.Override(1f);
        }
        else
        {
            vignette.intensity.Override(0.602f);
            return;
        }
    }
}
