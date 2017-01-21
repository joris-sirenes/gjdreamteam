using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    // Use this for initialization
    public Quaternion originalRotationValue;
    public bool boulePickup = false;
    public WeaponScript weapon_Ball = null, weapon_Basic = null;
    void Start () {
        
        WeaponScript[] weapons = GetComponentsInChildren<WeaponScript>(); ;

        foreach (WeaponScript weapon in weapons)
        {
            if (weapon.shotPrefab.tag.Equals("Boule"))
            {
                weapon_Ball = weapon;
            }
            else
            {
                weapon_Basic = weapon;
            }
        }
        originalRotationValue = weapon_Basic.transform.rotation;
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
        bool shoot_R = Input.GetKey(KeyCode.RightArrow);
        bool shoot_L = Input.GetKey(KeyCode.LeftArrow);
        bool shoot_U = Input.GetKey(KeyCode.UpArrow);
        bool shoot_D = Input.GetKey(KeyCode.DownArrow);
        bool shoot_Diag = Input.GetKey(KeyCode.LeftShift);
        // Careful: For Mac users, ctrl + arrow is a bad idea
        if (shoot_R || shoot_D|| shoot_L || shoot_U)
        {
            
                    if (boulePickup) {
                weapon_Ball.transform.rotation = originalRotationValue;
                        if (shoot_Diag && shoot_R)
                    weapon_Ball.direction = "UP-RIGHT";
                        else if (shoot_Diag && shoot_L)
                    weapon_Ball.direction = "UP-LEFT";
                        else if (shoot_U)
                    weapon_Ball.direction = "UP";
                        else if (shoot_R)
                    weapon_Ball.direction = "RIGHT";
                        else if (shoot_L)
                    weapon_Ball.direction = "LEFT";
                        else if (shoot_D)
                    weapon_Ball.direction = "DOWN";

                weapon_Ball.Attack(false);
                boulePickup = false;
            }
                 else
                {
                weapon_Basic.transform.rotation = originalRotationValue;
                    if (shoot_Diag && shoot_R)
                    weapon_Basic.direction = "UP-RIGHT";
                    else if (shoot_Diag && shoot_L)
                    weapon_Basic.direction = "UP-LEFT";
                    else if (shoot_U)
                    weapon_Basic.direction = "UP";
                    else if (shoot_R)
                    weapon_Basic.direction = "RIGHT";
                    else if (shoot_L)
                    weapon_Basic.direction = "LEFT";
                    else if (shoot_D)
                    weapon_Basic.direction = "DOWN";

                weapon_Basic.Attack(false);
                }
            }
            
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Boule"))
        {
            if (!boulePickup)
            {
                Destroy(col.gameObject);
                boulePickup = true;
            }
            
        }
    }
}

