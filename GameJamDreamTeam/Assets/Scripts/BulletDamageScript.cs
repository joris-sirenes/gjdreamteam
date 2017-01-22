using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageScript : MonoBehaviour
{
    public Transform anim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Destroy(col.gameObject);
            //Instantiate(anim, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }
     



    }
}