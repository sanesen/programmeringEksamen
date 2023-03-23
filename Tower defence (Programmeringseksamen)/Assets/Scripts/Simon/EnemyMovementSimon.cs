using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSimon : MonoBehaviour
{
    Rigidbody2D rb;
    public int strength;
    public float lives;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        strength = Random.Range(1, 10);
        Color opacity = Color.white;
        opacity.a = 1/10f*strength;
        this.gameObject.GetComponent<Renderer>().material.color = opacity;
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
