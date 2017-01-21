﻿using UnityEngine;
using System.Collections;
[AddComponentMenu("Custom/Editor")]
public class Grid : MonoBehaviour
{
    public float width = 1.0f;
    public float height = 1.0f;
    public Color color = Color.blue;
    void OnDrawGizmos()
    {
        Vector3 pos = Camera.current.transform.position;
        Gizmos.color = color;
        for (float y = pos.y - 250.0f; y < pos.y + 250.0f; y += height)
        {
            Gizmos.DrawLine(
            new Vector3(-250.0f, Mathf.Floor(y / height) * height, 0.0f),
            new Vector3(250.0f, Mathf.Floor(y / height) * height, 0.0f));
        }
        for (float x = pos.x - 250.0f; x < pos.x + 250.0f; x += width)
        {
            Gizmos.DrawLine(
            new Vector3(Mathf.Floor(x / width) * width, -250.0f, 0.0f),
            new Vector3(Mathf.Floor(x / width) * width, 250.0f, 0.0f));
        }
    }
}