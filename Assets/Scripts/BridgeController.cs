using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeController : MonoBehaviour
{
    private int totalScore = 0;
    public GameObject barrier;
    public GameObject bridge;


    public Text scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onCollect()
    {
        totalScore++;
        scoreText.text = "Score: " + totalScore;
        Debug.Log("Score is " + totalScore);
        if (totalScore == 3)
        {
            barrier.SetActive(false);
            bridge.SetActive(true);
        }


    }
}
