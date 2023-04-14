using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointInd = 0;

    public void Start()
    {
        //target = Movement.points[0];
    }
    public void Update()
    {
        //Vector2 dir = target.position - transform.position;
        //transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNewWaypoint();
        }
    }
    public void GetNewWaypoint()
    {
        if (wavepointInd >= Movement.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointInd++;
        target = Movement.points[wavepointInd];
    }

}

