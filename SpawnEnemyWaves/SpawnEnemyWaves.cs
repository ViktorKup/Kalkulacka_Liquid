// Script si delam pouze pro sebe, nedelam ho do zadneho skolniho projektu
using UnityEngine.AI

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
    
    private SpawnState state = SpawnState.Counting;

    void Update()
    {
        waveCountdown = timeBetweenWaves;
    }
    
    void SpawnEnemy(Transform enemy)
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
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
}
