using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : MonoBehaviour
{
    public List<GameObject> enemies;
    private TowerUpgrade tower;
    private TowerShooting towerShoot;


    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponentInParent<TowerUpgrade>();
        transform.localScale = Vector3.one * tower.range;
        towerShoot = GetComponentInParent<TowerShooting>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
        if (towerShoot.target == collision.gameObject.transform)
        {
            towerShoot.target = null;
        }
    }

    public void RangeUpdate()
    {
        transform.localScale = Vector3.one * tower.range;
    }
}
