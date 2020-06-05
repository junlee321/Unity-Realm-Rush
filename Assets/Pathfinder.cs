using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetStardAndEndColor();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        //Vector2Int gridPos = startWayPoint.GetGridPos();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWayPoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                //do nothing
            }
            print("Exploring" + explorationCoordinates);

            //int explorGridX = direction.x + gridPos.x;
            //int explorGridY = direction.y + gridPos.y;
            //print("Exploring"+ explorGridX + "," + explorGridY);
        }
    }

    private void SetStardAndEndColor()
    {
        startWayPoint.SetTopColor(Color.red);
        endWayPoint.SetTopColor(Color.gray);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.Log("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }   
    }
}
