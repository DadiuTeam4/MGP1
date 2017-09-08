using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour {
    public NavMeshAgent playerAI;

    void Start()
    {
        playerAI = gameObject.GetComponent<NavMeshAgent>();
    }

	public void MoveInDirection(Vector3 direction)
    {
		playerAI.Move(direction * 0.05f);
        playerAI.ResetPath();
	}
}