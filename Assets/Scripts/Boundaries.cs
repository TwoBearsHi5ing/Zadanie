using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private Vector2 screenBounds;
    private Camera mainCamera;

    public static Boundaries Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        edgeCollider = GetComponent<EdgeCollider2D>();
        mainCamera = Camera.main;
        FindBoundaries();
    }
    public void FindBoundaries()
    {
        screenBounds.x = 1 / (mainCamera.WorldToViewportPoint(new Vector3(mainCamera.transform.position.x + 1, mainCamera.transform.position.y + 1, 0)).x - 0.5f);
        screenBounds.y = 1 / (mainCamera.WorldToViewportPoint(new Vector3(mainCamera.transform.position.x + 1, mainCamera.transform.position.y + 1, 0)).y - 0.5f);
        Vector2 pointA = new Vector2(screenBounds.x / 2, screenBounds.y / 2);
        Vector2 pointB = new Vector2(screenBounds.x / 2, -screenBounds.y / 2);
        Vector2 pointC = new Vector2(-screenBounds.x / 2, -screenBounds.y / 2);
        Vector2 pointD = new Vector2(-screenBounds.x / 2, screenBounds.y / 2);

        Vector2[] tempArray = new Vector2[] { pointA, pointB, pointC, pointD, pointA };
        edgeCollider.points = tempArray;
    }
    public Vector2 GetScreenBounds()
    {
        return screenBounds / 2;
    }
}
