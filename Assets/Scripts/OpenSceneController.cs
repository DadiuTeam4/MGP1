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
		if (Input.anyKeyDown || Input.touchCount > 0)
        {
			SceneManager.LoadScene(nextScence, LoadSceneMode.Single);

        }

    }
}
