using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Animator anim;
    new Rigidbody2D rigidbody2D;

    public GameObject bulletPrefab;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool shooting = Input.GetMouseButton(0); //YOU TODO: make this come from player input 

        if (shooting)
        {
            anim.SetBool("Shooting", true);

            //Direction to mouse is a vector between mouse position (A) and the player (B), so (A-B): 
            Vector2 A = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 B = transform.position;
            Vector2 directionToMouse = (A - B).normalized;
            Debug.DrawLine(A, B); //this appears only in the editor 


            //YOU TODO: make the player shoot in the direction of the mouse 
            //(this code given in Tutorial 13) 
            if (Time.frameCount % 120 == 0 || Input.GetMouseButtonDown(0)) //shoot every 120 frames or if player just shot, NB: there are other ways to do this, this is quick and dirty 
                                                                           //can you explain why this isn't perfect? :) You should be able to notice inconsistency 
            {
                var spawnBullet = Instantiate(bulletPrefab, transform.position, Quaternion.FromToRotation(Vector2.up, directionToMouse));
                spawnBullet.GetComponent<Rigidbody2D>().velocity = spawnBullet.transform.up * 10f; //shoot in that direction 
            }

            anim.SetFloat("XSpeed", directionToMouse.x);
            anim.SetFloat("YSpeed", directionToMouse.y);

        }
        else
        {
            anim.SetBool("Shooting", false);
        }
    }
}