using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wavespawner : MonoBehaviour
{
    private const float V = 2f;
    public Transform enemyPrefab;

    public float CountdownTime = 10f;
    private float countdown = V;

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
        Debug.Log("Wave Incomming");
    }
}
