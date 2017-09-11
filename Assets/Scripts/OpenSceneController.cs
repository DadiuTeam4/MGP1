using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenSceneController : MonoBehaviour
{

    // Use this for initialization
    public string nextScence = "ProtoScene1";


    // Update is called once per frame
    void Update()
    {
		//Touchcount for tablet, anykeydown for mouse/unity test interface
		if (Input.touchCount > 0 ||Input.anyKeyDown)
        {
			SceneManager.LoadScene(nextScence, LoadSceneMode.Single);

        }

    }
}
