using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUpdateGIMaterial : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DynamicGI.updateThreshold = 100.0f;
        // get some boolean
        string gibool = DynamicGI.synchronousMode.ToString();
        Debug.Log(gibool);
        // default is false, let's make it true then
        DynamicGI.synchronousMode = true;
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Renderer>().UpdateGIMaterials();
        //DynamicGI.UpdateEnvironment();
        // I want to know ambient light color changes when the skybox is changed.
        // get ambient color first
        string ambientLightColorFlat = RenderSettings.ambientLight.ToString();
        string ambientLightColorAbove = RenderSettings.ambientSkyColor.ToString(); //.skybox.GetColor("_SkyTint").ToString();
        //string skyboxColor = RenderSettings.ambientEquatorColor
        //Debug.Log("flat" + ambientLightColorFlat + " and, " + "above" + ambientLightColorAbove + " and, " + "skybox.color" + skyboxColor);
        // why not change it

        if (Input.GetKeyDown("c"))
        {
            // some test
            ApplyRandomAmbientColor();
        }

    }

    void ApplyRandomAmbientColor()
    {
        DynamicGI.UpdateEnvironment();
        if (GetComponent<Renderer>() != null)
        {
            //RendererExtensions.UpdateGIMaterials(GetComponent<Renderer>());
            
        }
        // this is working?
        Debug.Log("apply");
        // get ambient probe
        //string probe = 
        //RenderSettings.ambientProbe.AddAmbientLight(Color.red);
        //Debug.Log(probe);
        //string threshold = DynamicGI.updateThreshold.ToString();
        //Debug.Log(threshold);
    }
}
