using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Powerups/Health")]
public class HealthPowerup : Powerup
{    
    public int healthAmount;
    
    public override void ApplyPowerup(GameObject player)
    {
        player.GetComponent<PlayerHealth>().maxHealth.Value += healthAmount;
        //note that we needed to use .Value above, because maxHealth is a FloatVal
        //this is a slight downside to this extended approach, as the code is a bit more verbose/ugly
    }
}
