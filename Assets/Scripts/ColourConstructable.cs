// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourConstructable : MonoBehaviour, Constructable {
    [Tooltip("The color added to the object")]
	public Color addedColour = new Color();
    private Renderer renderer;
    
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    public void Construct(){
        renderer.material.color *= addedColour;
    }
}