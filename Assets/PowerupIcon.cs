using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PowerupIcon : MonoBehaviour
{
    public Powerup powerup;
    
    public Image image;
    public TMP_Text label;
    
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = powerup.icon;
        label.text = powerup.name;
    }
    
    public void OnClick()
    {
        powerup.ApplyPowerup(GameObject.FindWithTag("Player"));
        
        //close the popup
        transform.parent.parent.gameObject.SetActive(false);
    }
}
