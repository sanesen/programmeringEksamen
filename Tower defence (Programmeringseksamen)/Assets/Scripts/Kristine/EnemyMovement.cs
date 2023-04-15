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

        //Indsætter hvor mange punkter der er på ruten
        Transform[] _rute = new Transform[16];

        //Kasper Schnejder B20
        for (int i = 0; i < _rute.Length; i++)
        {
            _rute[i] = rute.GetChild(i);

        }
        
        StartCoroutine(GoThroughRoute(_rute));
    }
  
    IEnumerator GoThroughRoute(Transform[] rute)
    {
        Vector2 origin = Vector2.zero; //sætter Origin til 0
        Vector2 target = Vector2.zero; //Sætter mål til 0

        //Forloop, som tilføjer hvert point, som det næste mål i rækkefølgen
        for (int i = 0; i < rute.Length - 1; i++) // i er en variable
        {
            origin = rute[i].position; // Hvergang dette kode kører, så ændre vores origin punkt fra 0 til den tidl. defineret rute[i] som er et punkt på ruten
            target = rute[i + 1].position; // Det næste mål på ruten

            //Bestemmer hvilken retning fjenden skal vende
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

            //Bestemmer farten for fjenden mellem punkterne
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
