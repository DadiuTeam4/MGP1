using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour, Touchable {
	public PlayerAI hugo;

	public void Interact(RaycastHit hit){
		hugo.playerAI.SetDestination(hit.point);
	}
}
