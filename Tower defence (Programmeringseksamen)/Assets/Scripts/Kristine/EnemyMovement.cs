using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform rute;

    public float speed = 5f;
    public float lives = 2;

    private void Start()
    {
        rute = ruteManager.Instance.transform;


        Transform[] _rute = new Transform[16];


        for (int i = 0; i < _rute.Length; i++)
        {
            _rute[i] = rute.GetChild(i);

        }
        StartCoroutine(GoThroughRoute(_rute));
    }
    IEnumerator GoThroughRoute(Transform[] rute)
    {
        Vector2 origin = Vector2.zero;
        Vector2 target = Vector2.zero;

        for (int i = 0; i < rute.Length - 1; i++)
        {
            origin = rute[i].position;
            target = rute[i + 1].position;

            if (target.x - origin.x > 0.1 && target.y - origin.y < 0.1 && target.y - origin.y > -0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (target.x - origin.x < 0.1 && target.y - origin.y > 0.1 && target.x - origin.x > -0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (target.x - origin.x < 0.1 && target.y - origin.y < -0.1 && target.x - origin.x > -0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (target.x - origin.x < -0.1 && target.y - origin.y < 0.1 && target.y - origin.y > -0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            float timeToGo = Vector2.Distance(origin, target) / speed;
            float timeElasped = 0;

            while (timeElasped < timeToGo)
            {
                transform.position = Vector2.Lerp(origin, target, timeElasped / timeToGo);
                timeElasped += Time.deltaTime;
                yield return null;
            }
            transform.position = target;
        }

    }

}
