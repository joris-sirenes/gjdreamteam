using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * 4.0f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * 4.0f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 4.0f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 4.0f * Time.deltaTime);
        }
    }
}
