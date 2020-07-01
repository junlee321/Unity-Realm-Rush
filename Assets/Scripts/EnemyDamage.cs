using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int enemyHitPoints = 10;
    [SerializeField] int damagePerHit = 1;

    [SerializeField] ParticleSystem enemyDeathFX;
    [SerializeField] ParticleSystem hitParticlePrefab;

    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip enemyExploed;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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
        var vfx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);

        AudioSource.PlayClipAtPoint(enemyExploed, Camera.main.transform.position);

        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        myAudioSource.PlayOneShot(hitSFX);

        enemyHitPoints -= damagePerHit;
        hitParticlePrefab.Play();
    }
}
