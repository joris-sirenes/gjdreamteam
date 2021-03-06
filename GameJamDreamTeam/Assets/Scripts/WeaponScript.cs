﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    public string direction;

    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 1f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

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

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

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

