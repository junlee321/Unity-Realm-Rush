using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParent;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        print(towerQueue.Count);
        int numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent;
        baseWaypoint.isPlaceable = false;

        //set the baseWaypoint
        newTower.baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldtower = towerQueue.Dequeue();

        oldtower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldtower.baseWaypoint = newBaseWaypoint;

        //move tiower to new pos
        oldtower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldtower);
    }
}
