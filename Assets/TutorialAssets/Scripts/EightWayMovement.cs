using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightWayMovement : MonoBehaviour
{
    public float speed = 5f;

    Animator anim;
    new Rigidbody2D rigidbody2D;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = (Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0);
        float inputY = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);

        if (inputX != 0 || inputY != 0)
        {
            anim.SetBool("Walking", true);

            anim.SetFloat("XSpeed", inputX);
            anim.SetFloat("YSpeed", inputY);

            // constant movement velocity at ANY angle
            Vector2 inputVector = new Vector2(inputX, inputY);
            if (inputVector.magnitude > 1) inputVector.Normalize();
            rigidbody2D.velocity = inputVector * speed;
        }
        else
        {
            anim.SetBool("Walking", false);

            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
