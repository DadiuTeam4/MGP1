using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenSceneController : MonoBehaviour
{

    // Use this for initialization


    public string nextScene;
    bool danish;
    public Transform danishTransform;
    bool english;
    public Transform englishTransform;
    public Transform Hugo;
    public Vector3 posHugo = new Vector3(-6.9f, -11.1f, -3.9f);
    public Transform GrandMa;
    public Vector3 posGrandma = new Vector3(15.6f, -14.9f, 6f);
    float timer;
    public Transform background;
    public LevelFade transition;
    Image img;

    void Start()
    {
        img = background.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {


        if (danish || english)
        {

            MoveHugo();

            if(timer > 9)
            {
               img.CrossFadeColor(new Color(1, 1, 1, 0), 2f, true, true);
               MoveGrandMa();
            }

            timer += Time.deltaTime;
        }

     /*   if(timer > 21)
        {
            Hugo.localScale = Vector3.Lerp(Hugo.localScale, Hugo.localScale * 0.9f, 0.05f);
            //Hugo.Rotate(Vector3.up);
            
            Hugo.position = Vector3.Lerp(Hugo.position, Hugo.position + Vector3.up * 4f + Vector3.right *2f + Vector3.forward * 5.0f, 0.05f);
        }*/

        if(timer > 18.0f)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        transition.FadeIn(nextScene);
    }

    public void Danish()
    {   
        danish = true;
        danishTransform.gameObject.SetActive(false);
        englishTransform.gameObject.SetActive(false);
		AkSoundEngine.SetState ("Speak_language", "DK"); 

       // StartBTN.gameObject.SetActive(true);

    }

    public void English()
    {
        english = true;
        danishTransform.gameObject.SetActive(false);
        englishTransform.gameObject.SetActive(false);
       // StartBTN.gameObject.SetActive(true);
		AkSoundEngine.SetState ("Speak_language", "UK"); 

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
