using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Powerup powerup;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = powerup.icon;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            powerup.Apply(other.gameObject);

            Destroy(gameObject);
        }
    }
}
