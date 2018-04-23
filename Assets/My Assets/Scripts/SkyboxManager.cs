using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour {
    private float t = 0.0f;
    private int environmentType = 0;
    public Material daysky;
    public Material nightsky;
    public Material gallerysky;

    public ReflectionProbe probe;

    // Use this for initialization
    void Start () {
		
	}

    void UpdateRelectionProbe()
    {
        /*
        probe.transform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y * -1,
            Camera.main.transform.position.z
        );
        */

        probe.RenderProbe();
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > 10.0f)
        {
            // change skybox based on valuable "environment type"
            if (environmentType == 0)
            {
                // increment
                environmentType += 1;
                RenderSettings.skybox = gallerysky;
                UpdateRelectionProbe();
                //DynamicGI.UpdateEnvironment();
            }
            else if (environmentType == 1)
            {
                environmentType += 1;
                RenderSettings.skybox = daysky;
                UpdateRelectionProbe();
                //DynamicGI.UpdateEnvironment();
            }
            else if (environmentType == 2)
            {
                // back to 0
                environmentType = 0;
                RenderSettings.skybox = nightsky;
                UpdateRelectionProbe();
                //DynamicGI.UpdateEnvironment();
            }
            t = 0.0f;
        }
	}
}
