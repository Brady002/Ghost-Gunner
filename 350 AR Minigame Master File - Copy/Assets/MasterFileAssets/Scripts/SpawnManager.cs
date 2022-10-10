using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies = new GameObject[2];
    private GameObject enemy;
    public int spawnDistance = 15;
    public int waveSpawn;
    public int enemyCount;
    private int wave = 1;
    private bool spawnNewWave = false;
    public GameObject parent;

    public GameObject[] powerUps = new GameObject[2];
    private GameObject powerUp;
    private bool spawnNewPower = false;

    void Start()
    {
        Vector3 spawnerPos = new Vector3 (parent.transform.position.x + 20, parent.transform.position.y, parent.transform.position.z);
        transform.position = spawnerPos; //Lets us adjust the spawning radius
        SpawnEnemy(1); //Spawns one enemy to start
        StartCoroutine(SpawnPowerUps());//
    }

    private Vector3 generateSpawnPos(int y) //Finds a spot in a circle to spawn enemy instances
    {
        parent.transform.Rotate(0, Random.Range(0, 360), 0); //Picks a random angle
        Vector3 randomPos = new Vector3(transform.position.x, y, transform.position.z); //Sets spawn location base on spawner position
        //Debug.Log(randomPos);
        return randomPos;
    }

    void Update()
    {
        //Debug.Log(wave);
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0) //Sets spawning interval, in this case when they all die
        {
            SpawnEnemy(wave);
            StartCoroutine(EnemySpawnLogic());
            StopCoroutine(EnemySpawnTimer());
            spawnNewWave = false;
        } else if (spawnNewWave == true) //Alternate logic for spawning interval based on time. Used for later waves
        {
            SpawnEnemy(wave);
            StartCoroutine(EnemySpawnLogic());
            StartCoroutine(EnemySpawnTimer());
            spawnNewWave = false;
        }

        if (spawnNewPower == true)//starts a timer for a powerup to spawn
        {
            StartCoroutine(SpawnPowerUps());
            spawnNewPower = false;
        }
    }

    IEnumerator EnemySpawnLogic() //Dictates how many enemies will spawn as time progresses
    {
        if(wave < 5)
        {
            yield return new WaitForSeconds(10);
            wave++;
        } else if (wave >= 5)
        {
            yield return new WaitForSeconds(20);
            wave++;
        }

    }

    IEnumerator EnemySpawnTimer() //Dicates when enemies will spawn, if all enemies aren't dead
    {
        if (wave > 5 && wave < 10)
        {
            yield return new WaitForSeconds(15);
            spawnNewWave = true;
        } else if (wave >= 10 && wave < 20)
        {
            yield return new WaitForSeconds(20);
            spawnNewWave = true;
        } else if (wave >= 20 && wave < 35)
        {
            yield return new WaitForSeconds(30);
            spawnNewWave = true;
        } else
        {
            spawnNewWave = false;
        }
    }

    private void PickEnemy()
    {
        float enemytype = Random.Range(0, 101); //Random 1/100 roll
        if (enemytype <= 70) //70% chance to spawn basic enemy
        {
            enemy = enemies[0];
        } else if (enemytype > 70 && enemytype <= 90)//20% chance to spawn orb
        {
            enemy = enemies[1];
        } else //10% chance to spawn cylinder
        {
            try
            {
                enemy = enemies[2];
            }
            catch
            {
                enemy = enemies[0];
            }
            
        }
    }

    private void SpawnEnemy(int enemies)
    {
        for (var i = 0; i < enemies; i++)
        {
            PickEnemy(); //Selects enemy to spawn before placing it in level
            Instantiate(enemy, generateSpawnPos(2), enemy.transform.rotation);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        Debug.Log("spawn power start");
        yield return new WaitForSeconds(10);
        //PickPower(); //unused because there's only 1 power right now
        powerUp = powerUps[0];
        Instantiate(powerUp, generateSpawnPos(2), powerUp.transform.rotation);
        spawnNewPower = true;
        Debug.Log("spawn power");
    }
}