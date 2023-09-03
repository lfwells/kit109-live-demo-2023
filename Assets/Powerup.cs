using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : ScriptableObject
{
    public Sprite icon;

    public virtual void Apply(GameObject player) { }
}
