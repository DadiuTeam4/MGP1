using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeConstrucShaderController : MonoBehaviour {

    Material material;
    Renderer rend;
    float num = 0;
    bool active;
    Destructable GO;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        material = rend.material;
        GO = this.gameObject.GetComponent<Destructable>();
    }
	
    void Update()
    {
        
	        float TimeGot = (GO.GetTimeAtFirstTrigger());

        if (TimeGot == 0)
            return;

        num = (Time.time - TimeGot);

        if(num > 0)
        {
            ChangeTex(1);
            active = true;
            num = num * 100;
            DeconstructAnim(num);
        }

        if(!GO.GetHasBeenSetToDestroy())
        {
            ChangeTex(0);
            active = false;
            num = 0;
            DeconstructAnim(num);
        }

    }

    public void ChangeTex(float _value)
    {
        material.SetFloat("_Gradiant", _value);
    }


	// Update is called once per frame
    public void DeconstructAnim(float _value)
    {
        material.SetFloat("_Intensity", _value);
    }

    

}
