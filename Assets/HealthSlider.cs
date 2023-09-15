using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public FloatVal currentHealth;      //these refer to the same FloatVals
    public FloatVal maxHealth;          //that PlayerHealth script does,
                                        //so no need for a public PlayerHealth reference

    //slider reference
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    //the actual interesting bit, using the FloatVals
    void Update()
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
}
