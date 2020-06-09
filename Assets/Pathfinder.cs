using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter; // the current searchCenter
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        SetStardAndEndColor();
        BreadthFristSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endWayPoint);

        Waypoint previous = endWayPoint.exploredFrorm;
        while (previous != startWayPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrorm;
        }

        path.Add(startWayPoint);
        path.Reverse();
    }

    private void BreadthFristSearch()
    {
        queue.Enqueue(startWayPoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

        print("Finished pathfinding");
    }

    private void HaltIfEndFound()
    {
        if (endWayPoint == searchCenter)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            //print("Exploring" + neighbourCoordinates);
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrorm = searchCenter;
            print("Queueing " + neighbour);
        }
    }

    private void SetStardAndEndColor()
    {
        // todo consider moveing out?
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
