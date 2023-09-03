using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerupIcon : MonoBehaviour
{
    Powerup powerup;

    public Image icon;
    public TMP_Text text;

    public void SetPowerup(Powerup powerup)
    {
        this.powerup = powerup;

        icon.sprite = powerup.icon;
        text.text = powerup.name;
    }

    public void OnClick()
    {
        //apply the powerup
        powerup.Apply(GameObject.FindGameObjectWithTag("Player"));

        //close the upgrade canvas
        transform.parent.parent.gameObject.SetActive(false);
    }
}
