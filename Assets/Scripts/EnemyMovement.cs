using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Range(0.5f, 10f)]
    [SerializeField] float movementPeriod = 0.5f;

    [SerializeField] ParticleSystem enemyBombFX;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FallowPath(path));
    }

    IEnumerator FallowPath(List<Waypoint>path)
    {
        print("Start patrol");

        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(enemyBombFX, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
    }
}
