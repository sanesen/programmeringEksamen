using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : MonoBehaviour
{
    public List<GameObject> enemies;
    private TowerUpgrade tower;


    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponentInParent<TowerUpgrade>();
        transform.localScale = Vector3.one * tower.range;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemies.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemies.Remove(collision.gameObject);
    }

    public void RangeUpdate()
    {
        transform.localScale = Vector3.one * tower.range;
    }
}
