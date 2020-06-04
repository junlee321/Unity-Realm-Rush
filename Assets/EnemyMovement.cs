﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator FallowPath()
    {
        print("Start patrol");

        foreach (Waypoint waypoint in path)
        {
            print("Visiting block" + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }

        print("Ending patrol");
    }
}
