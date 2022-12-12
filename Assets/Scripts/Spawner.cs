using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;

    [SerializeField] private int amountOfEnemies;

    private Vector2 Bounds;

    private void SpwanEnemies()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector2 SpawnPosition = new Vector2(Random.Range(-Bounds.x, Bounds.x), Random.Range(-Bounds.y, Bounds.y));

            var enemy = Instantiate(EnemyPrefab);
            enemy.SetActive(true);
            enemy.transform.position = SpawnPosition;
        }
    }
    private void Start()
    {
        Bounds = Boundaries.Instance.GetScreenBounds();
        SpwanEnemies();
    }
}
