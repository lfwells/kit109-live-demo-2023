using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public Sprite icon;
    
    public abstract void ApplyPowerup(GameObject player);
    
    
}

/* for benji <3
public class TemporaryPowerup : Powerup
{
    public Powerup powerup;
    public float buffTime;
    
    public override void ApplyPowerup(GameObject player)
    {
        player.StartCoroutine(BuffRoutine(player));
    }
    IEnumerator BuffRoutine(GameObject player)
    {
        powerup.ApplyPowerup(player);
        
        yield return WaitForSeconds(buffTime);
        
        //powerup.RevokePowerup(player);
    }
}
*/