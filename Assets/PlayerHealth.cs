using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), "Health: " + health + " / "+maxHealth);   
    }
}
