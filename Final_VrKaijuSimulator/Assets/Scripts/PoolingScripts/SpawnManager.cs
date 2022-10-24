using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public string tag;
        public GameObject objectPrefab;
        public int size;
    }

    public static SpawnManager instace;
    private void Awake()
    {
        instace = this;
    }
    public List<pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (pool apool in pools)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();
            for (int i = 0; i < apool.size; i++)
            {
                GameObject obj = Instantiate(apool.objectPrefab);
                obj.SetActive(false);
                objectQueue.Enqueue(obj);
            }
            poolDictionary.Add(apool.tag, objectQueue);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 spawnPoint)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(false);
        objectToSpawn.transform.position = spawnPoint;
        IObjectInterface pooledObject = objectToSpawn.GetComponent<IObjectInterface>();
        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawned();
        }
        return objectToSpawn;
    }
    public void ReleaseObject(string tag, GameObject objects)
    {
        poolDictionary[tag].Enqueue(objects);
    }
}
