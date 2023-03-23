using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Wavespawner : MonoBehaviour
{
    public Transform NormalenemyPrefab;
 
    public Transform spawnPoint;
    public float CDTime = 5f;
    public float countdown = 2f;


    public int WaveNum = 0;



    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = CDTime;
        }

        countdown -= Time.deltaTime;




        IEnumerator SpawnWave()
        {
            WaveNum++;

            for (int i = 0; i < WaveNum; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            Debug.Log("Wave Incoming!");

        }

         void SpawnEnemy()
        {
            Instantiate(NormalenemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
    }
}

