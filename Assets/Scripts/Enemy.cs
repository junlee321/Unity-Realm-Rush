using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyHitPoints = 10;
    [SerializeField] int damagePerHit = 1;

    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (enemyHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        enemyHitPoints -= damagePerHit;
        print(enemyHitPoints);
    }
}
