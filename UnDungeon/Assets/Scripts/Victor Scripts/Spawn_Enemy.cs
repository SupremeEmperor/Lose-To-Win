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
    public int enemyAmt = 0;
    public int maxEnemies;
    public int shooterAmt = 0;
    public int maxShooters;
    public GameObject[] spawnLocations;
    public GameObject[] availableEnemies;
    public int spawnBatchAmt = 6;
    public bool dialogueDone = true;
    public GameObject character;
    private int lvl;

    //Arrays: [6*1] [1, 2] [1, 2, 3] [1, 2, 3, 4] [1, 2, 3, 4, 5] [1, 2, 3, 4, 5, 6]
    //Parse in level => From character level, choose a different array

    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("Spawn Locations");
        availableEnemies = new GameObject[] { enemy1, enemy2, enemy3, enemy4, enemy5, enemy6 };
        //to be removed when dialouge is implemented
        startSpawning();
        character = GameObject.FindGameObjectWithTag("Player");
        lvl = character.GetComponent<MovementScript>().lvl;
    }

    // Update is called once per frame
    void Update()
    {
        lvl = character.GetComponent<MovementScript>().lvl;
    }

    public void Clear()
    {
        //This is a change
        shooterAmt = 0;
        enemyAmt = 0;
    }

    IEnumerator Spawn()
    {
        while (enabled)
        {
            lvl = character.GetComponent<MovementScript>().lvl;
            if (enemyAmt < maxEnemies && lvl > 0)
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
        GameObject chosen;
        switch (lvl)
        {
            case 1:
                chosen = enemies[Random.Range(0, 1)];
                break;
            case 2:
                chosen = enemies[Random.Range(0, 2)];
                break;
            case 3:
                chosen = enemies[Random.Range(1, 3)];
                break;
            case 4:
                chosen = enemies[Random.Range(2, 5)];
                break;
            case 5:
                chosen = enemies[Random.Range(5, 6)];
                break;
            default:
                chosen = enemies[Random.Range(0, enemies.Length)];
                break;
        }
        
        if (chosen == enemy3 || chosen == enemy6)
        {
            if(shooterAmt < maxShooters)
            {
                shooterAmt++;
                return chosen;
            }
            else
            {
                return enemies[0];
            }
        }
        return chosen;
    }

    public void startSpawning()
    {
        StartCoroutine(Spawn());
    }
}
