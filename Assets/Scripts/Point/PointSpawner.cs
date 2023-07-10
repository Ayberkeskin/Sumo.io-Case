using System.Collections;
using UnityEngine;


    public class PointSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 1;

        [SerializeField] private ObjectPool objectPool = null;

        [SerializeField] private Vector3 _spawnPositions;


        private void Start()
        {
            StartCoroutine(nameof(SpawnRoutine));
        }


        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                GameObject obj = objectPool.GetPoolObject();
                GenerateRandomPosition();
                obj.transform.position = _spawnPositions;
                yield return new WaitForSeconds(_spawnInterval);
            }
        }

        private void GenerateRandomPosition()
        {
            float x = Random.Range(-6.9f, 6.9f);
            float y = Random.Range(0.5f, 2f);
            float z = Random.Range(-6.9f, 6.9f);

            _spawnPositions = new Vector3(x, y, z);
        }
    }




