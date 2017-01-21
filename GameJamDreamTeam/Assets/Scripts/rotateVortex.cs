using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotateVortex : MonoBehaviour {
    float rotate;
	// Use this for initialization
	void Start () {
        rotate = 5f;
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject[] vortexes = GameObject.FindGameObjectsWithTag("Vortex");
        foreach (var vor in vortexes)
        {
            vor.transform.Rotate(0, 0, rotate);
        }
    }
}
