using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerShooting : MonoBehaviour
{
    private TowerDetection detection;
    public GameObject bullet;
    private GameObject bulletTemp;
    private Vector2 bulletDirection;
    private Transform tower;
    public float reloadTime, bulletspeed;
    private float timer;
    private string targetMode = "First";
    private List<float> enemyDistance = new List<float>();
    private List<int> enemyStrength = new List<int>();
    public int bulletDamage = 2;

    // Start is called before the first frame update
    void Start()
    {
        tower = this.transform;
        detection = GetComponentInChildren<TowerDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detection.enemies.Count != 0 && timer <= 0)
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

    public void ChooseTargetmode(int val)
    {
        switch (val)
        {
            case 0:
                targetMode = "First";
                break;
            case 1:
                targetMode = "Last";
                break;
            case 2:
                targetMode = "Closest";
                break;
            case 3:
                targetMode = "Strongest";
                break;
            case 4:
                targetMode = "Weakest";
                break;
            default:
                break;
        }

    }

    private void ShootFirst()
    {
        Shoot(0);
    }

    private void ShootLast()
    {
        Shoot(detection.enemies.Count - 1);
    }

    private void ShootClosest()
    {

        for (int i = 0; i < detection.enemies.Count; i++)
        {
            enemyDistance.Add(Vector2.Distance(tower.position, detection.enemies[i].transform.position));
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
        Shoot(index);
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
        Shoot(index);
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
        Shoot(index);
        enemyStrength.Clear();
    }

    private void Shoot(int enemyIndex)
    {
        bulletTemp = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletDirection = detection.enemies[enemyIndex].transform.position - tower.position;
        bulletTemp.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletspeed;
        bulletTemp.GetComponent<Bullet>().damage = bulletDamage;
        timer = reloadTime;
    }
}
