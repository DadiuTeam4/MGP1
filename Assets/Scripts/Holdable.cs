using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour {
    // time is the when the touch began!
	public virtual void Interact(RaycastHit hit, float time) {} 
}
