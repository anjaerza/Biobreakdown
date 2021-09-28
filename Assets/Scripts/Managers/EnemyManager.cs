using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    float enemyNumber;
    [SerializeField]float numeroEnemigos;


    void Start ()
    {
        if (spawnPoints.Length != 0)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }


    void Spawn()
    {
        if (spawnPoints.Length!=0)
        {
            enemyNumber++;
            //
            // if(playerHealth.currentHealth <= 0f)
            // {
            //   return;
            // }
            if (enemyNumber > numeroEnemigos)
            {
                return;
            }

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
