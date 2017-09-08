using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour, Touchable 
{
	private PlayerAI hugo;

	void Start() 
	{
		hugo = FindObjectOfType<PlayerAI>();
	}
	public void Interact(RaycastHit hit)
	{
		hugo.playerAI.SetDestination(hit.point);
	}
}
