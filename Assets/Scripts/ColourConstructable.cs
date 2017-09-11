// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColourConstructable : MonoBehaviour, Constructable {
    [Tooltip("The color added to the object")]
	public Color addedColour = new Color();
    private Renderer renderer;
    
    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    public void Construct(){
        Debug.Assert(renderer != null, "NO RENDERER FOUND ON OBJECT: " + gameObject.name);
        renderer.material.color *= addedColour;
    }
}