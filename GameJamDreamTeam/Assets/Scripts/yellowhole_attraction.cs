using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowhole_attraction : MonoBehaviour
{
    bool fill, repulse = false;
    GameObject boule;
    GameObject toRepulse;
    Vector3 position_trou;
    float diffX = 0;
    float diffY = 0;
    Vector2 directionRepulseX, directionRepulseY;
    float vitesse = 1.5f;
    bool stopX, stopY = false;
    Vector2 directionY;
    Vector2 directionX;
    int cptRepulse = 0;
    // Use this for initialization
    void Start()
    {
        position_trou = this.transform.position;
        boule = GameObject.FindGameObjectWithTag("Boule_jaune");

    }

    // Update is called once per frame
    void Update()
    {
        if (fill)
        {
            if (Mathf.Sign(diffX) == Mathf.Sign(position_trou.x - boule.transform.position.x))
                boule.transform.Translate(directionX * vitesse * Time.deltaTime);
            else
                stopX = true;
            if (Mathf.Sign(diffY) == Mathf.Sign(position_trou.y - boule.transform.position.y))
                boule.transform.Translate(directionY * vitesse * Time.deltaTime);
            else
                stopY = true;
            if (stopX && stopY)
            {
                Destroy(this);
                Destroy(GameObject.FindGameObjectWithTag("particule_jaune"));
                Destroy(boule);
            }
        }
        if (repulse)
        {
            if (cptRepulse < 15)
            {
                toRepulse.transform.Translate(directionRepulseX * vitesse * Time.deltaTime);
                toRepulse.transform.Translate(directionRepulseY * vitesse * Time.deltaTime);
                cptRepulse++;
            }
            else
            {
                repulse = false;
                cptRepulse = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D COL)
    {
        if (COL.gameObject.tag == "Boule_jaune")
        {
            diffX = position_trou.x - boule.transform.position.x;
            diffY = position_trou.y - boule.transform.position.y;
            fill = true;
            if (Mathf.Sign(position_trou.x - boule.transform.position.x) == -1)
                directionX = Vector2.left;
            else
                directionX = Vector2.right;
            if (Mathf.Sign(position_trou.x - boule.transform.position.x) == -1)
                directionY = Vector2.up;
            else
                directionY = Vector2.down;
        }
        else
        {
            toRepulse = COL.gameObject;
            repulse = true;
            if (position_trou.x - toRepulse.transform.position.x > 0)
                directionRepulseX = Vector2.left;
            else
                directionRepulseY = Vector2.right;
            if (position_trou.y - toRepulse.transform.position.y < 0)
                directionRepulseY = Vector2.up;
            else
                directionRepulseY = Vector2.down;

        }
    }
}
