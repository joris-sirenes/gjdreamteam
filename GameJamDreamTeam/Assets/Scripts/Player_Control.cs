using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        Jump();
        Shoot();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * 4f * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector2.up * 4f * Time.deltaTime);
        }
    }

    void Shoot()
    {
        bool shoot_R = Input.GetKeyDown(KeyCode.RightArrow);
        bool shoot_L = Input.GetKeyDown(KeyCode.LeftArrow);
        bool shoot_U = Input.GetKeyDown(KeyCode.UpArrow);
        bool shoot_D = Input.GetKeyDown(KeyCode.DownArrow);
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot_R || shoot_D|| shoot_L || shoot_U)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                if(shoot_U)
                    weapon.direction = "UP";
                if(shoot_R)
                    weapon.direction = "RIGHT";
                if (shoot_L)
                    weapon.direction = "LEFT";
                if (shoot_D) { 
                    weapon.direction = "DOWN";
                    transform.Translate(Vector2.up * 40f * Time.deltaTime );
                }
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }
    }
}

