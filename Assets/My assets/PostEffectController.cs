using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectController : MonoBehaviour {

    public float intensity;
    private Material material;

    // Creates a private material used to the effect
    void Awake()
    {
        material = new Material(Shader.Find("Hidden/CustomColorGrading"));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Postprocess the image
    //void OnRenderImage(RenderTexture source, RenderTexture destination)
    void OnPostRender(RenderTexture source, RenderTexture destination)
    {
        /*
        if (intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }
        */
        //Graphics.SetRenderTarget(RenderTexture);

        //material.SetFloat("_bwBlend", intensity);
        Graphics.Blit(source, destination, material);
    }
}
