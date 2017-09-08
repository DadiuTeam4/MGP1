using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeConstrucShaderController : MonoBehaviour {

    Material material;
    Renderer rend;
    float num = 0;
    bool active;

    [SerializeField]
    GameObject GO;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        material = rend.material;
        //GO.GetComponent<>
	}
	
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            ChangeTex(1);
            active = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeTex(0);
            num = 0;
            DeconstructAnim(num);
            active = false;
        }

        else if (active)
        {
            num += 2f;
            DeconstructAnim(num);
        }
        num = Mathf.Clamp(num, 0, 1000);

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
