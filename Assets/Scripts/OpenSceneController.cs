using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenSceneController : MonoBehaviour
{

    // Use this for initialization



    public string nextScene;
    public bool danish;
    public Transform danishTransform;
    public bool english;
    public Transform englishTransform;
    public Transform StartBTN;
    public Transform Hugo;
    public Vector3 posHugo = new Vector3(-6.9f, -11.1f, -3.9f);
    public Transform GrandMa;
    public Vector3 posGrandma = new Vector3(15.6f, -14.9f, 6f);


    // Update is called once per frame
    void Update()
    {
        /*	//Touchcount for tablet, anykeydown for mouse/unity test interface
            if (Input.touchCount > 0 ||Input.anyKeyDown)
            {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

            }
            */

        if (danish || english)
        {
            MoveHugo();
            MoveGrandMa();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    public void Danish()
    {   
        danish = true;
        danishTransform.gameObject.SetActive(false);
        englishTransform.gameObject.SetActive(false);
        StartBTN.gameObject.SetActive(true);
        

    }

    public void English()
    {
        english = true;
        danishTransform.gameObject.SetActive(false);
        englishTransform.gameObject.SetActive(false);
        StartBTN.gameObject.SetActive(true);
    }

    void MoveHugo()
    {
        Hugo.gameObject.SetActive(true);
        Hugo.position = Vector3.Lerp(Hugo.position, posHugo, 0.05f);
    }

    void MoveGrandMa()
    {
        GrandMa.gameObject.SetActive(true);
        GrandMa.position = Vector3.Lerp(GrandMa.position, posGrandma, 0.01f);
    }
}
