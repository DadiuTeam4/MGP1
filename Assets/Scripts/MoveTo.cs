// Author: Itai Yavin
// Contributor:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour, Touchable 
{
	private PlayerAI hugo;

    [SerializeField]
    private ParticleSystem particle;


    void Start() 
	{
		hugo = FindObjectOfType<PlayerAI>();
	}
	public void Interact(RaycastHit hit)
	{
		hugo.playerAI.SetDestination(hit.point);
        ParticleEffect(hit);
	}

    public void ParticleEffect (RaycastHit hit)
    {
        Instantiate(particle, hit.point, Quaternion.identity);
    }

}
