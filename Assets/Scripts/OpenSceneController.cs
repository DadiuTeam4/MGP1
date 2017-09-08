using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenSceneController : MonoBehaviour
{

    Text text;
    private bool isBlink = true;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(blink());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            SceneManager.LoadScene("Deconstructable", LoadSceneMode.Single);
        }

    }

    IEnumerator blink()
    {
        while (isBlink)
        {
            text.text = "";
            yield return new WaitForSeconds(0.5f);
            text.text = "Touch to Start ";
            yield return new WaitForSeconds(0.5f);
        }

    }
}
