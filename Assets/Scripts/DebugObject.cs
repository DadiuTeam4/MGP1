using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugObject : Rhythmic {
	protected override void Interact() 
	{
		print("Called");
        if (active)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;

        }

    }
}
