using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public FloatVal health;
    public FloatVal maxHealth;

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), "Health: " + health + " / "+maxHealth);
        //note that we can use health as a float here, because of the "magic" in FloatVal.cs
        //without the magic, we could have written the above line as:
        //GUI.TextArea(new Rect(10, 10, 100, 20), "Health: " + health.Value + " / " + maxHealth.Value);
    }
}
