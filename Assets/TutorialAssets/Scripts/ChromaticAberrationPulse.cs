using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrationPulse : MonoBehaviour {

    //the volume we are going to modify the settings for
    PostProcessVolume volume;

    //the setting we are going to modify
    ChromaticAberration chromaticAberrationSetting = null;

    //the way to change this setting's value over time
    public float sinMagnitude = 0.5f;
    public float sinOffset = 0.5f;
    public float speed = 10;

    // Use this for initialization
    void Start () 
    {
        //cache the volume
        volume = GetComponentInChildren<PostProcessVolume>();

        //get the setting on the profile 
        volume.profile.TryGetSettings<ChromaticAberration>(out chromaticAberrationSetting);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (chromaticAberrationSetting != null)
        {
            //using Sin() to get a nice up and down curve, maths nerds should love this:
            chromaticAberrationSetting.intensity.value = sinMagnitude * Mathf.Sin(Time.timeSinceLevelLoad * speed) + sinOffset;

            //note we could have also used an animation curve here, see example:
            //chromaticAberrationSetting.intensity.value = settingValueCurve.Evaluate(Time.timeSinceLevelLoad * speed);
        }
    }
}
