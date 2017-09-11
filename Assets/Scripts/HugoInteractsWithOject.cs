using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoInteractsWithOject : MonoBehaviour {

    Destructable GO;
    public HugoAnimation hugoAnim;

    // Use this for initialization
    void Start () {
       GO = GetComponent<Destructable>();
       //hugoAnim = hugoAnim.GetComponent<HugoAnimation>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (GO.GetHasBeenSetToDestroy())
        {
            hugoAnim.SetCountFingers(true);
        }
	}
}
