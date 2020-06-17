using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 100f)]
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
            Instantiate(enemys, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
