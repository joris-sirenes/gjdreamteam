using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    // Use this for initialization
    public Quaternion originalRotationValue;
    public bool boulePickup = false;
    public WeaponScript weapon_Basic = null;
    public WeaponBallScript weapon_Ball = null;
    public Transform shotPrefab;
    public string currentTag;

    void Start () {

        weapon_Basic = GetComponentInChildren<WeaponScript>();
        weapon_Ball = GetComponentInChildren<WeaponBallScript>();

        originalRotationValue = weapon_Basic.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
        bool shoot_Diag = Input.GetKey(KeyCode.LeftShift);

        if (shoot_R || shoot_D|| shoot_L || shoot_U)
        {
            if (boulePickup)
            {
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

                weapon_Ball.Attack(false, this.gameObject.GetComponent<Light>().color, currentTag);
                boulePickup = false;
                this.gameObject.GetComponent<Light>().color = Color.white;
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
        if (col.gameObject.tag.Contains("Boule"))
        {
            if (!boulePickup)
            {
                this.gameObject.GetComponent<Light>().color=col.gameObject.GetComponent<SpriteRenderer>().color;
                currentTag = col.gameObject.tag;
                Destroy(col.gameObject);
                boulePickup = true;
            }
            
        }
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }
}

