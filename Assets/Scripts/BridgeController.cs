using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BridgeController : MonoBehaviour, Constructable
{
    private int totalScore = 0;
    public GameObject barrier;
    public GameObject bridge;
	public TouchHandler touchHandler;

	public NavMeshAgent player;

	public Vector3 target = new Vector3(13f, 0.0f, -0.6f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(player.remainingDistance < 0.1)
		{
			touchHandler.isInputEnabled = true;
			barrier.SetActive(true);
		}
    }

    public void Construct()
    {
        totalScore++;
        Debug.Log("Score is " + totalScore);
        if (totalScore == 2)
        {
            barrier.SetActive(false);
            bridge.SetActive(true);
			movePlayerWalkOverBridge();
        }

    }

    private void movePlayerWalkOverBridge()
    {
		touchHandler.isInputEnabled = false;
		player.SetDestination(target);
	}
}
