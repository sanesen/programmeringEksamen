using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wavespawner : MonoBehaviour
{
    private const float V = 2f;
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float CountdownTime = 10f;
    private float countdown = V;
    private int WaveNum = 1;

    void Update()
    {
        if (countdown <=0f)
        {
            SpawnWave();
            countdown = CountdownTime;
        }
        countdown -= Time.deltaTime;
        
    }
    void SpawnWave()
    {
        for (int i = 0; i < WaveNum; i++)
        {
            SpawnEnemy();
        }
        Debug.Log("Wave Incomming");
        WaveNum++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);
    }
}
