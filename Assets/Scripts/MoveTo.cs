using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : Touchable {
	public NavMeshAgent hugo;

	override public void Interact(RaycastHit hit){
		hugo.SetDestination(hit.point);
	}
}
