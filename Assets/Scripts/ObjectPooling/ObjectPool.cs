using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class ObjectPool : MonoBehaviour
 {
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> PooledObject;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField] public Pool pool;
    [SerializeField] private Transform _parentPoint;

    private void Awake()
    {
        pool.PooledObject = new Queue<GameObject>();
        for(int i = 0;i< pool.poolSize; i++)
        {
            GameObject obj = Instantiate(pool.objectPrefab, _parentPoint);
            obj.SetActive(false);
            pool.PooledObject.Enqueue(obj);
        }
    }
    public GameObject GetPoolObject() 
    {
        if (pool.PooledObject.Count==0)
            AddS�zePool(5);
        GameObject obj= pool.PooledObject.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    
    public void SetPoolObject(GameObject pooledObject) 
    {
        pool.PooledObject.Enqueue(pooledObject);
        pooledObject.SetActive(false);
    
    }
    //E�er yeterli say�da obje kalmad� ise amount say�s� kadar yenisini spawn eder ve kuyru�a sokar
    public void AddS�zePool(float amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(pool.objectPrefab, _parentPoint);
            obj.SetActive(true);
            pool.PooledObject.Enqueue(obj); 
        }

    }


}




