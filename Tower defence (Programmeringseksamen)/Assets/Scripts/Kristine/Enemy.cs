using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform rute;
    public static Transform[] points;
    public float speed = 10f;
    public float MaHealth;
    public float CuHealth;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i]=transform.GetChild(i);
        }

        CuHealth = MaHealth;

        Transform[] rute = new Transform[14];

    

    }
   

}    
