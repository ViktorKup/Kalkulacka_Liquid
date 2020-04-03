// Script si delam pouze pro sebe, nedelam ho do zadneho skolniho projektu
using UnityEngine;


public class SpawnEnemyWaves : MonoBehaviour
{

    public enum SpawnState{Spawning, Waiting, Counting}
    
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnpoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    public float enemyLifeTime;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;
    
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {

        if (state == SpawnState.Waiting)
        {
            if (!IsEnemyAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        nextWave++;
    }

    bool IsEnemyAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("enemy").Length == 0f)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.Spawning;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        state = SpawnState.Waiting;
    }

    void SpawnEnemy(Transform enemy)
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
        Destroy(GameObject.FindWithTag("enemy"), enemyLifeTime);
    }

}
