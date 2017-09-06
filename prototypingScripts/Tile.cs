using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Touchable 
{
	[SerializeField]
	private Material[] materials;
	private Renderer rend;

	void Start() 
	{
		rend = GetComponent<Renderer>();
		rend.material = materials[0];
	}
	public override void Interact() 
	{
		rend.material = materials[1];
	}
}
