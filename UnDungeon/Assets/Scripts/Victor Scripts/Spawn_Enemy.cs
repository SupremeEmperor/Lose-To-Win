using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public int timeBetweenSpawn;
    public float maxXDistance;
    public float maxYDistance;
    private int enemyAmt = 0;
    public int maxEnemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        while (enabled)
        {
            if (enemyAmt < maxEnemies)
            {
                Instantiate(enemy1, new Vector3(Random.Range(-maxXDistance, maxXDistance), Random.Range(-maxYDistance, maxYDistance), 0), Quaternion.identity);
                Instantiate(enemy2, new Vector3(Random.Range(-maxXDistance, maxXDistance), Random.Range(-maxYDistance, maxYDistance), 0), Quaternion.identity);
                Instantiate(enemy3, new Vector3(Random.Range(-maxXDistance, maxXDistance), Random.Range(-maxYDistance, maxYDistance), 0), Quaternion.identity);
                Instantiate(enemy4, new Vector3(Random.Range(-maxXDistance, maxXDistance), Random.Range(-maxYDistance, maxYDistance), 0), Quaternion.identity);
                Instantiate(enemy5, new Vector3(Random.Range(-maxXDistance, maxXDistance), Random.Range(-maxYDistance, maxYDistance), 0), Quaternion.identity);
                Instantiate(enemy6, new Vector3(Random.Range(-maxXDistance, maxXDistance), Random.Range(-maxYDistance, maxYDistance), 0), Quaternion.identity);
                enemyAmt += 6;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);

        }

    }

    public void enemyDied()
    {
        enemyAmt -= 1;
    }
}
