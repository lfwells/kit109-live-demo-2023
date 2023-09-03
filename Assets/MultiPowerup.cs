using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultiPowerup", menuName = "Powerups/Multi")]
public class MultiPowerup : Powerup
{
    public List<Powerup> powerups;

    public override void Apply(GameObject player)
    {
        foreach (Powerup powerup in powerups)
        {
            powerup.Apply(player);
        }
    }
}
