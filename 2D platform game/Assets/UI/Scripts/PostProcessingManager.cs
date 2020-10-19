using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
public PostProcessVolume volume;
public float bloomValue;
public GameObject introMenu;


    void Update()
    {
        Bloom bloom;

        if (introMenu.activeSelf == true)
        {
            if (volume.profile.TryGetSettings<Bloom>(out bloom))
            {
                bloom.intensity.value = bloomValue;
            }
        }
        else
        {
            if (volume.profile.TryGetSettings<Bloom>(out bloom))
            {
                //default value
                bloom.intensity.value = 0.8f; 
                //postProcessingManager.SetActive(false);
                return;
            }
        }
    }
}