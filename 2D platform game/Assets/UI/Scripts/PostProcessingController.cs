using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette vignette = null;
    private Grain grain = null;

    void Start () 
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out grain);
        InvokeRepeating("SetNewPostProcessingValues", Random.Range(1.0f, 3.0f), 0.1f);  //1s delay, repeat every 1s
    }
    void SetNewPostProcessingValues() 
    {
        vignette.smoothness.value = Random.Range(0.8f, 1.0f);
        grain.intensity.value = Random.Range(0.35f, 0.65f);
        grain.size.value = Random.Range(1.20f, 1.50f);
    }
}
