using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    private EnemyWeaponScript weapon;
    public bool right = true;

    private float posx;
    private float posy;

    void getPos()
    {
        posx = transform.position.x;
        posy = transform.position.y;
    }


    void Start()
    {
        getPos();
        iTween.MoveTo(this.gameObject, new Vector3(posx + 2, posy, 0), 3);

    }
    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponentInChildren<EnemyWeaponScript>();
    }

    void Update()
    {
        //print(transform.position.x);
        if (transform.position.x >= posx + 2)
        {
            iTween.MoveTo(this.gameObject, new Vector3(posx - 2.2f, posy, 0), 3);
            right = false;

        }
        else if (transform.position.x <= posx - 2)
        {
            right = true;
            iTween.MoveTo(this.gameObject, new Vector3(posx + 2.2f, posy, 0), 3);

        }
        if (weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true, right);
        }
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        rigidbodyComponent.velocity = movement;
    }
}
