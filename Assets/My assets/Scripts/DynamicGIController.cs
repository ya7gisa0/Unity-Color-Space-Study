using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGIController : MonoBehaviour {
    // change GI in run time
    private Skybox skybox;
    private Material skyboxMat;
    private float t = 0.0f;
    private Color currentSkyTint;
    private Color initTint;

    //D05353FF
    Color colorA = new Color(208 / 256, 83 / 256, 189 / 256, 1.0f);
    Color colorB = new Color(208 / 256, 83 / 256, 83 / 256, 1.0f);
    

    void Start()
    {
        // get a reference of the skybox
        skybox = GetComponent<Skybox>();
        skyboxMat = skybox.material;
        string name = skybox.material.name;
        Debug.Log(name);

        // set inital sky tint
        currentSkyTint = colorA;
        initTint = currentSkyTint;
        
        //RenderSettings.skybox.SetColor("_Tint", new Color(0, 0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
        t += Mathf.Sin(Time.time);
        // get color

        currentSkyTint = Color.Lerp(colorA, colorB, t);
        skyboxMat.SetColor("_SkyTint", currentSkyTint);
	}
}
