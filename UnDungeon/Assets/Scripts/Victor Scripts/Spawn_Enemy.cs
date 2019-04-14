﻿using System.Collections;
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
    public int enemyAmt = 0;
    public int maxEnemies;
    public int shooterAmt = 0;
    public int maxShooters;
    public GameObject[] spawnLocations;
    public GameObject[] availableEnemies;
    public int spawnBatchAmt = 6;
    public bool dialogueDone = true;

    //Arrays: [6*1] [1, 2] [1, 2, 3] [1, 2, 3, 4] [1, 2, 3, 4, 5] [1, 2, 3, 4, 5, 6]
    //Parse in level => From character level, choose a different array

    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawn Locations");
        availableEnemies = new GameObject[] { enemy1, enemy2, enemy3, enemy4, enemy5, enemy6 };
        //to be removed when dialouge is implemented
        startSpawning();
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
                for (int i = 0; i < spawnBatchAmt; i++)
                {
                    Instantiate(getRandomEnemy(availableEnemies), getRandomItem(spawnLocations).transform.position, Quaternion.identity);
                    enemyAmt += 1;
                }
            }
            yield return new WaitForSeconds(timeBetweenSpawn);

        }

    }

    public void enemyDied()
    {
        enemyAmt --;
    }

    public void shooterDied()
    {
        shooterAmt --;
    }

    public GameObject getRandomItem(GameObject[] items)
    {
        return items[Random.Range(0, items.Length)];
    }

    public GameObject getRandomEnemy(GameObject[] enemies)
    {
        GameObject chosen = enemies[Random.Range(0, enemies.Length)];
        if (chosen == enemy3 || chosen == enemy6)
        {
            if(shooterAmt < maxShooters)
            {
                shooterAmt++;
                return chosen;
            }
            else
            {
                return getRandomEnemy(enemies);
            }
        }
        return chosen;
    }

    public void startSpawning()
    {
        StartCoroutine(Spawn());
    }
}
