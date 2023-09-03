using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaxHealthPowerup", menuName = "Powerups/Max Health")]
public class MaxHealthPowerup : Powerup
{
    public int maxHealthIncrease = 10;

    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerHealth>().maxHealth += maxHealthIncrease;
    }
}