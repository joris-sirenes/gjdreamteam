using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexRotate : MonoBehaviour {

    float rotate;
    public SpriteRenderer vortex;
    // Use this for initialization
    void Start()
    {
        rotate = 5f;
        vortex = this.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject[] vortexes = GameObject.FindGameObjectsWithTag("Vortex");
        //foreach (var vor in vortexes)
        //{
        //    vor.transform.Rotate(0, 0, rotate);
        //}
        vortex.transform.Rotate(0, 0, rotate);
    }

    public void stopRotate()
    {
        this.rotate = 0f;
    }
}
