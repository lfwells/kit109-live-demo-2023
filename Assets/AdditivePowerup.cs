using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Additive")]
public class AdditivePowerup : Powerup
{
    public FloatVal statToAdd;
    public float addAmount;

    public override void ApplyPowerup(GameObject player)    //note we don't even need to use the player
    {                                                       //one downside to this, is that this code doesn't immediately work for multiple players
        statToAdd.Value += addAmount;
    }
}
