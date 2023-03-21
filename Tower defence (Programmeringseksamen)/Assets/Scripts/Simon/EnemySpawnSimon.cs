using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSimon : MonoBehaviour
{
    public GameObject enemy, enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemySpawn()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
