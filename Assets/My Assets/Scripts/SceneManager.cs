using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {
    private float t = 0.0f;
    private bool isDay = true;
    public Material daysky;
    public Material nightsky;
    

	// Use this for initialization
	void Start () {
        //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("minimal reflection purple");
        UnityEngine.SceneManagement.SceneManager.LoadScene("minimal reflection sky", LoadSceneMode.Additive);
        
        //SceneManager.LoadScene("scenename");
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;

        if (t > 10.0f)
        {
            if (isDay)
            {
                isDay = false;
                // change skybox
                RenderSettings.skybox = nightsky;
                //UnityEngine.SceneManagement.SceneManager.
                UnityEngine.SceneManagement.SceneManager.LoadScene("minimal reflection purple", LoadSceneMode.Additive);
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("minimal reflection sky");
                DynamicGI.UpdateEnvironment();
                //DynamicGI.UpdateMaterials();
                //GetComponent<Renderer>().UpdateGIMaterials();
            } else
            {
                isDay = true;
                RenderSettings.skybox = daysky;
                UnityEngine.SceneManagement.SceneManager.LoadScene("minimal reflection sky", LoadSceneMode.Additive);
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("minimal reflection purple");
                DynamicGI.UpdateEnvironment();
                //GetComponent<Renderer>().UpdateGIMaterials();
            }
            t = 0.0f;
        }
		
	}
}
