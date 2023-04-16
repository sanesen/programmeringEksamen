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
    private List<float> enemyStrength = new List<float>();
    private float bulletSwayX, bulletSwayY;
    public Transform target;

    void Start()
    {
        //Reference skabes til t�rnets position, der bruges n�r t�rnet skal skyde
        towerPos = this.transform;

        //Referencer skabes til t�rnets detektionsomr�de og t�rnets stats
        detection = GetComponentInChildren<TowerDetection>();
        tower = GetComponent<TowerUpgrade>();
    }

    
    void Update()
    {
        //T�rnets rotation opdateres hver frame
        UpdateRotation();

        //Tjekker t�rnets targetmode, der bestemmer hvilken fjende der skal skydes efter. K�res s� l�nge der er fjender indenfor r�kkevidde
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

    //S�tter t�rnets target til den fjende, der er l�ngst fremme indenfor t�rnets r�kkevidde
    private void ShootFirst()
    {
        target = detection.enemies[0].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(0);
        }
    }

    //S�tter t�rnets target til den fjende, der er l�ngst tilbage indenfor t�rnets r�kkevidde
    private void ShootLast()
    {
        target = detection.enemies[detection.enemies.Count - 1].transform;
        if (detection.enemies.Count != 0 && timer <= 0)
        {
            Shoot(detection.enemies.Count - 1);
        }
    }


    //S�tter t�rnets target til den fjende, der er t�ttest p� t�rnet indenfor r�kkevidde
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

    //S�tter t�rnets target til den fjende, der har mest liv indenfor t�rnets r�kkevidde
    private void ShootStrongest()
    {
        for (int i = 0; i < detection.enemies.Count; i++)
        {
            enemyStrength.Add(detection.enemies[i].GetComponent<EnemyMovement>().lives);
        }

        float strongest = enemyStrength[0];
        int index = 0;

        //Sorterer fjenderne indenfor r�kkevidde, ved at sammenligne hver fjendes liv med den hidtil st�rkeste fjende og udskifte denne hvis den nye fjende har mere liv
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

    //S�tter t�rnets target til den fjende, der har mindst liv indenfor t�rnets r�kkevidde
    private void ShootWeakest()
    {
        for (int i = 0; i < detection.enemies.Count; i++)
        {
            enemyStrength.Add(detection.enemies[i].GetComponent<EnemyMovementSimon>().strength);
        }

        float weakest = enemyStrength[0];
        int index = 0;

        //Sorterer fjenderne indenfor r�kkevidde, ved at sammenligne hver fjendes liv med den hidtil svageste fjende og udskifte denne hvis den nye fjende har mindre liv
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

    //Skyder et projektil mod t�rnets target, ved at finde vektoren mellem t�rnets og fjendens positioner
    private void Shoot(int enemyIndex)
    {
        bulletSwayX = Random.Range(-100 / tower.accuracy, 100 / tower.accuracy);
        bulletSwayY = Random.Range(-100 / tower.accuracy, 100 / tower.accuracy);
        bulletTemp = Instantiate(bullet, towerPos.position, Quaternion.identity);
        bulletDirection = new Vector3(detection.enemies[enemyIndex].transform.position.x + bulletSwayX, detection.enemies[enemyIndex].transform.position.y + bulletSwayY) - towerPos.position;
        bulletTemp.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletspeed;
        bulletTemp.GetComponent<Bullet>().damage = tower.damage;

        //Resetter timeren alt efter t�rnets firerate
        timer = 200 / tower.fireRate;
    }

    //Opdaterer t�rnets rotation, s� t�rnet altid peger i retning af dets target
    void UpdateRotation()
    {
        if (target != null)
        {
            Vector3 dir = Vector3.RotateTowards(transform.up, target.position - towerPos.position, Mathf.PI, 0);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        }
    }
}
