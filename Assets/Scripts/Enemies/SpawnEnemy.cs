using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemyPrefab;

    public int initialAmount;
    public int maxEnemies;
    public int population;

    public float spawnFrequency;
    public Vector2 spawnRange;

    private float lastSpawnTime;

    private Transform enemyContainer;


    void Start() {
        GameObject container = new GameObject("Enemy Container (" + gameObject.name + ")");
        enemyContainer = container.transform;

        for (int i = 0; i < initialAmount; i++) {
            spawnEnemy();
        }
    }

    void Update() {
        if (TrackColonySize.colonySize > 0 || !TrackColonySize.hasGameStarted) {
            if (enemyContainer.childCount < maxEnemies) {
                if (Time.time - lastSpawnTime > spawnFrequency) {
                    if (population > 0 || population == -1) {
                        spawnEnemy();
                        lastSpawnTime = Time.time;

                        if (population > 0) {
                            population--;
                        }
                    }
                }
            }
        }
    }

    private void spawnEnemy() {
        float spawnDistance = Random.RandomRange(spawnRange.x, spawnRange.y);
        float spawnAngle = Random.RandomRange(0, 2 * Mathf.PI);

        Vector3 spawnLocation = transform.position + Vector3.right * spawnDistance * Mathf.Cos(spawnAngle) + Vector3.up * spawnDistance * Mathf.Sin(spawnAngle);
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        enemy.transform.parent = enemyContainer;
        enemy.GetComponent<EnemyController>().spawner = this;
    }
}
