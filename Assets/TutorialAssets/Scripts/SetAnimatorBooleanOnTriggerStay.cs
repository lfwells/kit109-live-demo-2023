using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorBooleanOnTriggerStay : MonoBehaviour 
{
	public string booleanName;
    public bool applyToOther;


	void OnTriggerEnter2D(Collider2D other)
	{
		var otherAnimator = applyToOther ? other.GetComponent<Animator> () : GetComponent<Animator>();
		if (otherAnimator) {
			otherAnimator.SetBool (booleanName, true);
		}
	}
	void OnTriggerExit2D(Collider2D other)
    {
        var otherAnimator = applyToOther ? other.GetComponent<Animator>() : GetComponent<Animator>();
        if (otherAnimator) {
			otherAnimator.SetBool (booleanName, false);
		}
	}
}
