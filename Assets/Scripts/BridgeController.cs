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

    public GameObject BridgeLogicTextObject;
    public NavMeshAgent player;

    public Vector3 target = new Vector3(13f, 0.0f, -0.6f);

    private bool isBridgeLogicFinished = false;
    private bool isBridgeLogicActive = false;
    // Update is called once per frame
    void Update()
    {
        if (player.remainingDistance < 0.1 && !isBridgeLogicFinished && isBridgeLogicActive)
        {
            touchHandler.isInputEnabled = true;
            barrier.SetActive(true);
            isBridgeLogicFinished = true;
            isBridgeLogicActive = false;
            BridgeLogicTextObject.GetComponent<Text>().text =  "Finish Bridge Logic";
            StartCoroutine(DestroyText());
        }
    }

    public void Construct()
    {
        totalScore++;
        Debug.Log("Score is " + totalScore);
        if (totalScore == 2)
        {
            touchHandler.isInputEnabled = false;
            BridgeLogicTextObject.SetActive(true);
            BridgeLogicTextObject.GetComponent<Text>().text =  "Now Start Bridge Logic";
            bridge.SetActive(true);
            StartCoroutine(movePlayerWalkOverBridge());
        }

    }

    IEnumerator movePlayerWalkOverBridge()
    {
        yield return new WaitForSeconds(3f);
        barrier.SetActive(false);
        player.SetDestination(target);
        isBridgeLogicActive = true;
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(3f);
        Destroy(BridgeLogicTextObject);
    }

}
