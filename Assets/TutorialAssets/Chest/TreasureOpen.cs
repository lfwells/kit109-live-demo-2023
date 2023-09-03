using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TreasureOpen : MonoBehaviour {
    
    public PlayableDirector directorToPlay;

    public List<Powerup> powerups;
    public GameObject upgradeCanvas;
    public GameObject powerupIcon;
   
    bool inArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inArea = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inArea = false;
    }

    private void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.Space))
        {
            directorToPlay.Play();
            
            upgradeCanvas.SetActive(true);
            foreach (var powerup in powerups)
            {
                var icon = Instantiate(powerupIcon, upgradeCanvas.transform.GetChild(0));
                icon.GetComponent<PowerupIcon>().SetPowerup(powerup);                
            }
        }
    }
}
