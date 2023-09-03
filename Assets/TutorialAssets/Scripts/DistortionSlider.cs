using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DistortionSlider : MonoBehaviour
{
    
    //the volume we are going to modify the settings for
    public PostProcessVolume volume;

    //the setting we are going to modify
    LensDistortion setting = null;

    // Use this for initialization
    void Start () {
        //get the setting on the profile 
        volume.profile.TryGetSettings<LensDistortion>(out setting);
    }

    //value will be a float between -50 and 50
    public void OnValueChanged(float value)
    {
        print(value);
        //TODO: update the intensity value of the setting object.
    }
}
