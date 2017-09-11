using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HugoAnimation : MonoBehaviour {

    Animator anim;
    Vector3 oldPos;
    float timer = 0;
    float speed;
    bool countFingers;
    bool pickup;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        oldPos = transform.position;            
	}
	
	// Update is called once per frame
	void Update () {
        
        //Speed
        Vector3 currentPos = transform.position;
        speed = (currentPos - oldPos).magnitude*10;
        anim.SetFloat("Speed", speed);
        oldPos = transform.position;


        //Fingers
        if (speed < 0.1)
        {
            timer += Time.deltaTime;
        }
        //if (timer > 5.0f)
        if(countFingers)
        {
            anim.SetBool("Fingers", true);
        }

        //Pick Up
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("PickUp", true);
            timer = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("pickup") &&
             anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            anim.SetBool("PickUp", false);
            timer = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("count_fingers") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            anim.SetBool("Fingers", false);
            timer = 0;
        }



    }


    public void SetCountFingers(bool _countFingers)
    {
        countFingers = _countFingers;
    }

    public void SetPickUp( bool _pickUp)
    {
        pickup = _pickUp;
    }
}
