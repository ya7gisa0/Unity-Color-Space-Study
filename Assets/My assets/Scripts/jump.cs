using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
    private float t = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // check the location of the game obj
        t += Time.deltaTime;
        if (t > 5.0f)
        {
            t = 0.0f;
            // get pos
            Vector3 pos = gameObject.transform.localPosition;
            // move up
            gameObject.transform.localPosition = new Vector3(pos.x, pos.y + Random.Range(5.0f, 12.0f), pos.z);
            gameObject.transform.Rotate(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        }
	}
}
