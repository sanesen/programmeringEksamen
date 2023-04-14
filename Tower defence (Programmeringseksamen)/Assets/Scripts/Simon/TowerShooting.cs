using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerShooting : MonoBehaviour
{
    private TowerDetection detection;
    private TowerUpgrade tower;
    public GameObject bullet;
    private GameObject bulletTemp;
    private Vector2 bulletDirection;
    private Transform towerPos;
    public float bulletspeed;
    private float timer;
    public string targetMode = "First";
    public int targetModeIndex = 0;
    private List<float> enemyDistance = new List<float>();
    private List<int> enemyStrength = new List<int>();
    private float bulletSwayX, bulletSwayY;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        towerPos = this.transform;
        detection = GetComponentInChildren<TowerDetection>();
        tower = GetComponent<TowerUpgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();

        if (detection.enemies.Count != 0)
        {
            switch (targetMode)
            {
                case "First":
                    ShootFirst();
                    break;
                case "Last":
                    ShootLast();
                    break;
                case "Closest":
                    ShootClosest();
                    break;
                case "Strongest":
                    ShootStrongest();
                    break;
                case "Weakest":
                    ShootWeakest();
                    break;
                default:
                    break;
            }
        }



        timer -= Time.deltaTime;
    }


    private void ShootFirst()
    {
        target = detection.enemies[0].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(0);
        }
    }

    private void ShootLast()
    {
        target = detection.enemies[detection.enemies.Count - 1].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(detection.enemies.Count - 1);
        }
    }

    private void ShootClosest()
    {
        for (int i = 0; i < detection.enemies.Count; i++)
        {
            enemyDistance.Add(Vector2.Distance(towerPos.position, detection.enemies[i].transform.position));
        }

        float closest = enemyDistance[0];
        int index = 0;

        for (int i = 0; i < enemyDistance.Count; i++)
        {
            if (enemyDistance[i] < closest)
            {
                closest = enemyDistance[i];
                index = i;
            }
        }
        target = detection.enemies[index].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(index);
        }

        enemyDistance.Clear();
    }

    private void ShootStrongest()
    {
        for (int i = 0; i < detection.enemies.Count; i++)
        {
            enemyStrength.Add(detection.enemies[i].GetComponent<EnemyMovementSimon>().strength);
        }

        int strongest = enemyStrength[0];
        int index = 0;

        for (int i = 0; i < enemyStrength.Count; i++)
        {
            if (enemyStrength[i] > strongest)
            {
                strongest = enemyStrength[i];
                index = i;
            }
        }
        target = detection.enemies[index].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(index);
        }
        enemyStrength.Clear();
    }

    private void ShootWeakest()
    {
        for (int i = 0; i < detection.enemies.Count; i++)
        {
            enemyStrength.Add(detection.enemies[i].GetComponent<EnemyMovementSimon>().strength);
        }

        int weakest = enemyStrength[0];
        int index = 0;

        for (int i = 0; i < enemyStrength.Count; i++)
        {
            if (enemyStrength[i] < weakest)
            {
                weakest = enemyStrength[i];
                index = i;
            }
        }
        target = detection.enemies[index].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(index);
        }
        enemyStrength.Clear();
    }

    private void Shoot(int enemyIndex)
    {
        bulletSwayX = Random.Range(-100 / tower.accuracy, 100 / tower.accuracy);
        bulletSwayY = Random.Range(-100 / tower.accuracy, 100 / tower.accuracy);
        bulletTemp = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletDirection = new Vector3(detection.enemies[enemyIndex].transform.position.x + bulletSwayX, detection.enemies[enemyIndex].transform.position.y + bulletSwayY) - towerPos.position;
        bulletTemp.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletspeed;
        bulletTemp.GetComponent<Bullet>().damage = tower.damage;
        timer = tower.fireRate;
    }
    void UpdateRotation()
    {
        if (target != null)
        {
            Vector3 dir = Vector3.RotateTowards(transform.up, target.position - transform.position, Mathf.PI, 0);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        }

    }
}
