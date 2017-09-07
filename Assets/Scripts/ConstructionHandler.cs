using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionHandler : MonoBehaviour {
	public GameObject[] ones, twos, threes, fours, fives;
	private int totalScore = 0;
	public GameObject barrier;
	public GameObject bridge;

	public Text scoreText;

	public void SendResource(int value){
		int rnd;
		switch(value){
			case 1:
				rnd = Random.Range(0, ones.Length);
				ones[rnd].GetComponent<Constructable>().Construct();
			break;

			case 2:
				rnd = Random.Range(0, twos.Length);
				twos[rnd].GetComponent<Constructable>().Construct();
			break;
			
			case 3:
				rnd = Random.Range(0, threes.Length);
				threes[rnd].GetComponent<Constructable>().Construct();
			break;
			
			case 4:
				rnd = Random.Range(0, fours.Length);
				fours[rnd].GetComponent<Constructable>().Construct();
			break;
			
			case 5:
				rnd = Random.Range(0, fives.Length);
				fives[rnd].GetComponent<Constructable>().Construct();
			break;
			
			default:
				Debug.Log("THIS VALUE IS NOT A VALID CONSTRUCTION VALUE: " + value);
			break;
		}
		totalScore++;
		scoreText.text = "Score: " + totalScore;
		Debug.Log("Score is " + totalScore);
		if(totalScore == 3)
		{
			barrier.SetActive(false);
			bridge.SetActive(true);
		}
	}
}
