using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "Powerups/Speed")]
public class SpeedPowerup : Powerup
{
    public float speedMultipiler = 1.1f;
    
    public override void ApplyPowerup(GameObject player)
    {
        player.GetComponent<EightWayMovement>().speed *= speedMultipiler;
    }
}
