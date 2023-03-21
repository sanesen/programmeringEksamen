using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSimon : MonoBehaviour
{
    Rigidbody2D rb;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-1, 0);
    }
}
