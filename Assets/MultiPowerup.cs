using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Multi", menuName = "Powerups/Multi Powerup")]
public class MultiPowerup : Powerup
{
    public List<Powerup> powerups;
    
    public override void ApplyPowerup(GameObject player)
    {
        //for (var i = 0; i < powerups.Count; i++)
        foreach (var powerup in powerups)
        {
            powerup.ApplyPowerup(player);
        }
        
        //higher-level functions, not today
        //powerups.ForEach((p) => p.ApplyPowerup(player))
    }
}
