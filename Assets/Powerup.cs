using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Powerups/BasicPowerUp")]
public class Powerup : ScriptableObject
{
    public Sprite icon;
    
    public int healthAmount;
    
    public void ApplyPowerup(GameObject player)
    {
        player.GetComponent<PlayerHealth>().maxHealth += healthAmount;
    }
}
