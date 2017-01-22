using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectShotScript : MonoBehaviour
{
    private WaveReflectScript weapon;
    private float posx0;
    private float posx1;
    private bool right=false, proc=false;
    private int test=1;

    // Use this for initialization
    void Start()
    {
        posx0 = this.transform.position.x;
    }
    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponentInChildren<WaveReflectScript>();
    }
    // Update is called once per frame
    void Update()
    {
        posx1 = this.transform.position.x;
        float Res = posx0 - posx1;
        if (Res < 0)
        {
            right = true;
        }
        else
        {
            right = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print(right);
        if (col.gameObject.tag.Equals("Missile") && !proc)
            {

            Destroy(col.gameObject);
            proc = true;
            Destroy(this.gameObject);
        }
        //test = 2;

        
    }
}