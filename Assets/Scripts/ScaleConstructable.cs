using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleConstructable : MonoBehaviour, Constructable {
	public Vector3 scaleAmount = new Vector3();
    public void Construct(){
        gameObject.transform.localScale += scaleAmount;
    }
}
