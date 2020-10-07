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
                //Debug.Log("ActiveScene...");
            }
        }
        else
        {
            if (volume.profile.TryGetSettings<Bloom>(out bloom))
            {
                bloom.intensity.value = 0.8f; //default value
                //Debug.Log("Scene is not active...");
                return;
            }
        }
    }
}