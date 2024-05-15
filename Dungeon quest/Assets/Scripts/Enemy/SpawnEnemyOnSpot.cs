using UnityEngine;

public class SpawnEnemyOnSpot : MonoBehaviour
{
    public GameObject enemy;
    public int enemyHealth;
    public int enemyDamage;


    public EnemySpawnSpot[] FindAllSpotsToSpawnEnemies()
    {
        return GameObject.FindObjectsOfType<EnemySpawnSpot>();
    }

    public void SpawnEnemiesOnSpots()
    {
        enemyHealth = PlayerPrefs.GetInt("enemy health");
        enemyDamage = PlayerPrefs.GetInt("enemy damage");

        EnemySpawnSpot[] enemySpawnSpot = FindAllSpotsToSpawnEnemies();

        for(int i = 0; i < enemySpawnSpot.Length; i++)
        {
            enemy.GetComponent<Buddy>().maxHealth = enemyHealth;
            enemy.GetComponent<EnemyAI>().damage = enemyDamage;
            Instantiate(enemy, enemySpawnSpot[i].transform.position, Quaternion.identity);
        }
    }
}
