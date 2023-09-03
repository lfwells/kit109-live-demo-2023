using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterZoomZoneScript : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCameraToActivate;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");

            //YOU TODO: Activate the attached virtual camera


        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("exit");

            //You TODO: Deactivate the attached virtual camera


        }
    }
}
