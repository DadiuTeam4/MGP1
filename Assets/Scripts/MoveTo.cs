using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour, Touchable {
	public NavMeshAgent hugo;

	public void Interact(RaycastHit hit){
		hugo.SetDestination(hit.point);
	}
}
