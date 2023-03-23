using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform rute;
    
    public float speed = 5f;
    public float MaHealth;
    public float CuHealth;

    private void Start()
    {
        rute = ruteManager.Instance.transform;
        CuHealth = MaHealth;

        Transform[] _rute = new Transform[Movement.points.Length];


        for (int i = 0; i < _rute.Length; i++)
        {
            _rute[i] = rute.GetChild(i);

        }
        StartCoroutine(GoThroughRoute(_rute));
    }
   IEnumerator GoThroughRoute(Transform[]rute)
    {
        Vector2 origin = Vector2.zero;
        Vector2 target = Vector2.zero;

        for (int i = 0; i < rute.Length-1; i++)
        {
            origin = rute[i].position;
            target = rute[i + 1].position;

            float timeToGo = Vector2.Distance(origin, target)/speed;
            float timeElasped = 0;

            while (timeElasped<timeToGo)
            {
                transform.position = Vector2.Lerp(origin, target, timeElasped / timeToGo);
                timeElasped += Time.deltaTime;
                yield return null;
            }
            transform.position = target;
        }
        
    }

}    
