using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public List<Powerup> powerupsToChooseFrom;
    
    Powerup chosenPowerup;
    
    void Start()
    {
        chosenPowerup = powerupsToChooseFrom[Random.Range(0, powerupsToChooseFrom.Count)];
        GetComponent<SpriteRenderer>().sprite = chosenPowerup.icon;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chosenPowerup.ApplyPowerup(other.gameObject);
            
            Destroy(gameObject);
        }
    }
}
