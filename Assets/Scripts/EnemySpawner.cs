using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 100f)]
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] EnemyMovement enemy;
    [SerializeField] Transform enemyParent;
    [SerializeField] Text spawndEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
        spawndEnemies.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemy()
    {
        while (true)//forever
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            

            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void AddScore()
    {
        score++;
        spawndEnemies.text = score.ToString();
    }
}
