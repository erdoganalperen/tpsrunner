using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPool Instance;

    public List<Pool> pools;

    Dictionary<string, Queue<GameObject>> _poolDictionary;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            print("tag doesnt exist");
            return null;
        }
        GameObject objToSpawn = _poolDictionary[tag].Dequeue();
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        objToSpawn.SetActive(true);
        return objToSpawn;
    }

    public void ReturnToPool(string tag,GameObject gameObject)
    {
        gameObject.SetActive(false);
        _poolDictionary[tag].Enqueue(gameObject);
    }
}