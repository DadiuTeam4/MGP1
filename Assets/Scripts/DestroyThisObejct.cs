using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisObejct : MonoBehaviour {

    float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer = timer + Time.deltaTime;

        if (timer > 3)
        {
            Destroy(this.gameObject);
        }

    }
}
