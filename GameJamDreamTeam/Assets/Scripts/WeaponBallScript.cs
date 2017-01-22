using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponBallScript : MonoBehaviour
{
    public string direction;
    public Transform shotPrefab;
    public float shootingRate = 1f;
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy, Color color, string tag)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            shotTransform.tag = tag.Substring(6, tag.Length - 6);
            shotTransform.GetComponent<SpriteRenderer>().color = color;


            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it

            
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                switch (direction)
                {
                    case "UP-RIGHT":
                        this.transform.Rotate(new Vector3(0, 0, -45));
                        move.direction = this.transform.up;
                        transform.parent.transform.Translate(Vector2.left * 1f * Time.deltaTime);
                        break;
                    case "UP-LEFT":
                        this.transform.Rotate(new Vector3(0, 0, 45));
                        move.direction = this.transform.up;
                        shot.gameObject.transform.Rotate(new Vector3(0, 0, 90));
                        transform.parent.transform.Translate(Vector2.right * 1f * Time.deltaTime);
                        break;
                    case "UP":
                        move.direction = this.transform.up;
                        shot.gameObject.transform.Rotate(new Vector3(0, 0, 45));
                        break;
                    case "DOWN":
                        move.direction = -this.transform.up;
                        shot.gameObject.transform.Rotate(new Vector3(0, 0, -135));
                        transform.parent.transform.Translate(Vector2.up * 40f * Time.deltaTime);
                        break;
                    case "RIGHT":
                        move.direction = this.transform.right;
                        shot.gameObject.transform.Rotate(new Vector3(0, 0, -45));
                        transform.parent.transform.Translate(Vector2.left * 2f * Time.deltaTime);
                        break;
                    case "LEFT":
                        move.direction = -this.transform.right;
                        shot.gameObject.transform.Rotate(new Vector3(0, 0, 135));
                        transform.parent.transform.Translate(Vector2.right * 2f * Time.deltaTime);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}

