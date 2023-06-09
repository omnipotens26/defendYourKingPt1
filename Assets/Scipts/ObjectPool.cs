using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] GameObject ennemyPrefab;
    
    [Range(0.1f, 10f)] float spawnTimer = 1f;
    GameObject[] pool;

    private void Awake() {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++){
            pool[i] = Instantiate(ennemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start(){
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        while (true){
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false){
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
