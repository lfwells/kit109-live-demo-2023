using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetAnimatorBooleanOnInput : MonoBehaviour
{
    public string animatorBoolean;
    public KeyCode key;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //this script is extremely basic for changing the state of the enemy to be scared of the player or not
        //you could use any logic to change this (by reading the player's health, the enemy's health, the number of enemies, the speed of the player etc)
        if (Input.GetKeyDown(key))
        {
            ChangeState();
        }
    }

    public void ChangeState()
    {
        anim.SetBool(animatorBoolean, !anim.GetBool(animatorBoolean));
    }
}
