using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  // Import DoTween namespace

public class CollectBlock : MonoBehaviour
{
    public Transform endLocation;  // Assign the destination in the Inspector
    public float moveDuration = 1.5f;  // Time it takes to move to the end location
    public Ease moveEase = Ease.Linear;  // Type of easing for the movement

    // Set intermediate waypoints for a curvy path (you can adjust this manually in Inspector or script)
    public Vector3[] waypoints;  

    private void OnMouseDown()
    {
        // On click, move the block to the end location with a curvy path
        MoveAlongCurvyPath();
    }

    void MoveAlongCurvyPath()
    {
        // Define the waypoints between the starting and ending position to make the movement curvy
        Vector3[] pathPoints = new Vector3[waypoints.Length + 2];
        pathPoints[0] = transform.position;  // Start point is the current position
        for (int i = 0; i < waypoints.Length; i++)
        {
            pathPoints[i + 1] = waypoints[i];  // Assign custom waypoints
        }
        pathPoints[pathPoints.Length - 1] = endLocation.position;  // Final point is the end location

        // Move the block along the curved path
        transform.DOPath(pathPoints, moveDuration, PathType.CatmullRom)
            .SetEase(moveEase)
            .OnComplete(OnReachEnd);
    }

    void OnReachEnd()
    {
        // This function will be called once the block reaches the end location
        Debug.Log("Block reached the end location!");

        // Add other actions like increasing score, destroying the block, etc.
        Destroy(gameObject);  // Example action: Destroy the block after reaching the target
    }
}
