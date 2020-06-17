using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] EnemyMovement enemys;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
    }

    IEnumerator RepeatedlySpawnEnemy()
    {
        while (true)//forever
        {
            print("spawning");
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
