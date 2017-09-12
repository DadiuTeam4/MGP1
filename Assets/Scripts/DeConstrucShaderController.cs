using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeConstrucShaderController : MonoBehaviour {

    Material material;
    public Material [] materials;
    Renderer rend;
    public Renderer[] rends;
    public float num = 0;
    public bool active;
    Destructable GO;
    public bool children;

	// Use this for initialization
	void Start () {

        if(transform.childCount > 0)
        {
            rends = GetComponentsInChildren<Renderer>();
            materials = new Material[rends.Length];
            for(int i = 0; i < rends.Length; i++)
            {
                materials[i] = rends[i].materials[0];
            }
            children = true;
        }
        else
        {
            rend = GetComponent<Renderer>();
            material = rend.material;
            children = false;
        }



        GO = this.gameObject.GetComponent<Destructable>();
    }
	
    void Update()
    {


            float TimeGot = (GO.GetTimeAtFirstTrigger());

            if (TimeGot == 0)
                return;

            num = (Time.time - TimeGot);

        if (num > 0 && GO.GetHasBeenSetToDestroy())
        {
            active = true;
            num = num * 100;
            num = Mathf.Clamp(num, 0, 500);
            if (!children)
            {
                ChangeTex(1);
                DeconstructAnim(num);
            }
            else if (children)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    ChangeTex(1, i);
                    DeconstructAnim(num, i);
                }
            }
        }

        //commect yeah
        if (!GO.GetHasBeenSetToDestroy())
        {
            active = false;
            num = 0;

            if (!children)
            {
                ChangeTex(0);
                DeconstructAnim(0); 
            }
            else if (children)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    ChangeTex(0, i);
                    DeconstructAnim(0, i);
                }
            }
        }
    }

    public void ChangeTex(float _value)
    {
        material.SetFloat("_Gradiant", _value);
    }

    public void DeconstructAnim(float _value)
    {
        material.SetFloat("_Intensity", _value);
    }

    public void ChangeTex(float _value, int index)
    {
        materials[index].SetFloat("_Gradiant", _value);
    }

    public void DeconstructAnim(float _value, int index)
    {
        materials[index].SetFloat("_Intensity", _value);
    }



}
