using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TreasureOpen : MonoBehaviour {
    
    public PlayableDirector directorToPlay;
    
    public GameObject upgradeCanvas;
    public GameObject powerupButtonPrefab;
    public List<Powerup> thingsInTheChest;
   
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

            foreach (var powerup in thingsInTheChest)
            {
                var button = Instantiate(powerupButtonPrefab, upgradeCanvas.transform.GetChild(0));
                button.GetComponent<PowerupIcon>().powerup = powerup;
            }
        }
    }
}
