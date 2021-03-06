﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureFadeOut : MonoBehaviour {

     Texture2D blk;
     public bool fade;
     public float alph;
     void Start(){
         //make a tiny black texture
         blk = new Texture2D (1, 1);
         blk.SetPixel (0, 0, new Color(0,0,0,0));
         blk.Apply ();
		 fade=!fade;
     }
     // put it on your screen
     void OnGUI(){
         GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height),blk);
     }
     
     void Update () {
        // if(Input.GetKeyDown("space")){fade=!fade;}
         
         
         if (!fade) {
             if (alph > 0) {
                 alph -= Time.deltaTime * .2f;
                 if (alph < 0) {alph = 0f;}
                 blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
                 blk.Apply ();
             }
         } 
         if (fade) {
             if (alph < 1) {
                 alph += Time.deltaTime * .2f;
                 if (alph > 1) {alph = 1f; SceneManager.LoadScene(0);}
                 blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
                 blk.Apply ();
             }
         }
     }

}
