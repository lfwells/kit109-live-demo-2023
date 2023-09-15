using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Multiply")]
public class MultiplyPowerup : Powerup
{
    public FloatVal statToMultiply;
    public float multiplyAmount = 1;

    public override void ApplyPowerup(GameObject player)    //note we don't even need to use the player
    {                                                       //one downside to this, is that this code doesn't immediately work for multiple players
        statToMultiply.Value *= multiplyAmount;
    }
}
