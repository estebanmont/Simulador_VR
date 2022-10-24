using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    SpawnManager manager;
    [SerializeField] GameObject[] spawnPoints;
    GameObject[] ships;
    float elapsedTime;
    [SerializeField] float timeBetweenSpawns;
    private void Start()
    {
        ships = new GameObject[spawnPoints.Length];
        manager = SpawnManager.instace;
    }
    private void Update()
    {
        if (elapsedTime>= timeBetweenSpawns)
        {
            Spawn();
            elapsedTime = 0f;
        }
        elapsedTime += Time.deltaTime;
    }
    private void Spawn()
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i] == null)
            {
                GameObject ship = manager.SpawnFromPool("Ships1", spawnPoints[i].transform.position);
                ships[i] = ship;
                return;
            }
        }
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i] != null)
            {
                manager.ReleaseObject("Ships1", ships[i]);
                ships[i] = null;
            }
        }
    }
}
