// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleConstructable : MonoBehaviour, Constructable {
    [Tooltip("Amount of scale added to object")]
	public Vector3 scaleAmount = new Vector3();
    public void Construct(){
        gameObject.transform.localScale += scaleAmount;
		//AKSOUNDENGINE.POSTEVENT
    }
}
