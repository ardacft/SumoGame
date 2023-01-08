using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    //public GameObject powerUp;
    public static int EnemyNumber = 0; 
    private float spawnPosition = 8; 

    // Update is called once per frame
    void Update()
    {
        if (EnemyNumber < 3)
        {
            Instantiate(enemy, new Vector3(Random.Range(-spawnPosition, spawnPosition), 3.1f, Random.Range(-spawnPosition, spawnPosition)), enemy.transform.rotation);
            EnemyNumber++;
            Debug.Log(EnemyNumber);
        }
    }
}
