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
    Color colorA = new Color(208, 83, 189, 1.0f);
    Color colorB = new Color(208 / 256, 83 / 256, 83 / 256, 1.0f);
    

    void Start()
    {
        colorA = new Color(208/255f, 83 / 255f, 189 / 255f);
        colorB = new Color(65 / 255f, 208 / 255f, 246 / 255f);
        // get a reference of the skybox
        //skybox = GetComponent<Skybox>();
        //skyboxMat = skybox.material;
        //string name = skybox.material.name;
        //Debug.Log(name);

        // set inital sky tint
        //currentSkyTint = colorA;
        //initTint = currentSkyTint;

        //RenderSettings.skybox.SetColor("_Tint", new Color(0, 0, 0, 0));

        // ambient mode?
        string currentAmbientMode = RenderSettings.ambientMode.ToString();
        Debug.Log(currentAmbientMode);
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t < 5.0f)
        {
            //skyboxMat.SetColor("_SkyTint", colorA);
            RenderSettings.skybox.SetColor("_SkyTint", colorA);// = colorA;
            RenderSettings.ambientSkyColor = colorA;
            DynamicGI.UpdateEnvironment();
        }
        else if (t < 10.0f)
        {
            //skyboxMat.SetColor("_SkyTint", colorB);
            RenderSettings.skybox.SetColor("_SkyTint", colorB);
            //RenderSettings.ambientLight = colorB;
            RenderSettings.ambientSkyColor = colorB;
            DynamicGI.UpdateEnvironment();
            
        }
        else
        {
            t = 0.0f;
        }
        Debug.Log(DynamicGI.isConverged.ToString());
        
        //t += Mathf.Sin(Time.time);
        // get color

        //currentSkyTint = Color.Lerp(colorA, colorB, t);
        //skyboxMat.SetColor("_SkyTint", currentSkyTint);
	}
}
