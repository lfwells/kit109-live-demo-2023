using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Author: Lachlan Hopkins (lwlh)
    Edited (Heavily) by: Lindsay Wells
	Date: 2017
	Purpose: A simple fair randomised list with weights. Originally created for capstone project, now open for all to use.
	Contact: chickatrice.net, github.com/Lachee
*/
public class RistExample : MonoBehaviour
{
    //you can have a RIST of anything, like colours, numbers, etc. Here we have a weighted list of game objects.
    public Rist<GameObject> weightedList;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0) //too lazy to even use a coroutine here :)
        {
            var go = weightedList.Next(Random.value);
            Instantiate(go);
        }
    }
}
