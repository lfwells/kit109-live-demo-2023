using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaxSpeedPowerup", menuName = "Powerups/Max Speed")]
public class MaxSpeedPowerup : Powerup
{
    public int maxSpeedIncrease = 10;

    public override void Apply(GameObject player)
    {
        player.GetComponent<EightWayMovement>().speed += maxSpeedIncrease;
    }
}