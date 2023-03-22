using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("Hit");
    //    if (collision.gameObject.GetComponent<EnemyMovementSimon>().lives <= 0)
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //    else
    //    {
    //        collision.gameObject.GetComponent<EnemyMovementSimon>().lives--;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyMovementSimon>().lives--;
        if (collision.GetComponent<EnemyMovementSimon>().lives <= 0)
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
