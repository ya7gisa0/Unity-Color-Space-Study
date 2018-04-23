using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectController : MonoBehaviour {

    public Material material;
    // for debug...
    private float t = 0.0f;
    private bool isSaturated = true;

    void Update()
    {
        t += Time.deltaTime;
        if (t > 5.0f)
        {
            t = 0.0f;
            if (isSaturated)
            {
                isSaturated = false;
            }
            else
            {
                isSaturated = true;
            }
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isSaturated)
        {
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
        
    }
}
