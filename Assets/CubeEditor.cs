using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] //only allow selection in the hierarchy
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabl();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize
            );
    }

    private void UpdateLabl()
    {
        int gridSize = waypoint.GetGridSize();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        string labelText = 
            waypoint.GetGridPos().x +
            "," +
            waypoint.GetGridPos().y;

        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
