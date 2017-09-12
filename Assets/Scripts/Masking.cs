using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Masking : MonoBehaviour {

    [SerializeField, Tooltip("Make sure that the particle system are in the same layer")]
    private LayerMask maskLayer;

    [SerializeField, Tooltip("Open to control material setting")]
    private Material material;

    [SerializeField, Tooltip("The material that appeares when masked (RGB)")]
    private Texture fantasayWorld;

    [SerializeField, Tooltip("Outline where fanatasy world can appear in (greyscale)")]
    private Texture outLine;
     
    

    void Awake()
    {

        if (transform.childCount > 0)
            return;


        GameObject GM = new GameObject();
        GM.AddComponent<Camera>();
        GM.transform.position = this.transform.position;
        GM.transform.rotation = this.transform.rotation;
        GM.transform.SetParent(this.transform);
        GM.name = "Mask Camera";
        Camera cam = GM.GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color(0, 0, 0);
        RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        rt.Create();
        cam.targetTexture = rt;
        cam.cullingMask = maskLayer;
        material = new Material(Shader.Find("Hidden/Masking"));
        material.SetTexture("_RenderTex", rt);
        material.SetTexture("_FantasyWorld", fantasayWorld);
        material.SetTexture("_Outline", outLine);

    }


    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
