using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerShooting : MonoBehaviour
{
    TowerDetection detection;
    public GameObject bullet;
    private GameObject bulletTemp;
    private Vector2 bulletDirection;
    private Transform tower;
    public float reloadTime, bulletspeed;
    private float timer;
    private string targetMode;
    public List<float> enemyDistance = new List<float>();

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
            targetMode = "Closest";
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
                default:
                    break;
            }
        }

        timer -= Time.deltaTime;
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

        float smallestNumber = enemyDistance[0];
        int index = 0;

        for (int i = 0; i < enemyDistance.Count; i++)
        {
            if (enemyDistance[i] < smallestNumber)
            {
                smallestNumber = enemyDistance[i];
                index = i;
            }
        }
        Shoot(index);
        enemyDistance.Clear();
    }

    private void Shoot(int enemyIndex)
    {
        bulletTemp = Instantiate(bullet, this.transform.position, Quaternion.identity);
        bulletDirection = detection.enemies[enemyIndex].transform.position - tower.position;
        bulletTemp.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletspeed;
        timer = reloadTime;
    }
}
