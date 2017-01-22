using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Attraction : MonoBehaviour {

    public string color;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D COL)
    {
        if (COL.gameObject.tag.Contains(color))
        {
            this.GetComponentInParent<VortexRotate>().stopRotate();
            Destroy(COL.gameObject);
        }
    }
}
