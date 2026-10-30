using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour 
{
    [SerializeField] public int wave;
    [SerializeField] public int enemiesLeft;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemiesLeftToSpawn;
    [SerializeField] private Vector3 spawnLocation;
    
    private float extraEnemies;
    private float _interval = 3f;
    private float _time;
    private bool _isSpawning = false; 

    void Awake()
    {
        _time = 0f;
    }

    void Update() 
    {
        _time += Time.deltaTime;

        while (_time >= _interval) 
        {
            CheckEnemiesLeft();
            _time -= _interval;
        }
    }

    void CheckEnemiesLeft()
    {
        if (enemiesLeft == 0 && !_isSpawning)
        {
            wave = wave + 1;
            extraEnemies = wave * 0.5f;
            int intExtraEnemies = (int)extraEnemies;
            
            enemiesLeftToSpawn = 5 + intExtraEnemies;
            enemiesLeft = enemiesLeftToSpawn; 

            StartCoroutine(StartWave(enemiesLeftToSpawn, 1f));
        }
    }

    IEnumerator StartWave(int count, float delay) 
    {
        _isSpawning = true;

        for (int i = 0; i < count; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            var prefab = enemyPrefabs[enemyIndex];
            
            Instantiate(prefab, spawnLocation, prefab.transform.rotation);
            
            yield return new WaitForSeconds(delay);
        }

        _isSpawning = false;
    }
}
