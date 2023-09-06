using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Powerups/Health")]
public class HealthPowerup : Powerup
{    
    public int healthAmount;
    
    public override void ApplyPowerup(GameObject player)
    {
        player.GetComponent<PlayerHealth>().maxHealth += healthAmount;
    }
}
