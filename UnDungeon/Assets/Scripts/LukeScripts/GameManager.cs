using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject character;
    GameObject[] enemies;
    int lastlvl;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        lastlvl = character.GetComponent<MovementScript>().lvl;
    }

    // Update is called once per frame
    void Update()
    {
        if (character.GetComponent<MovementScript>().lvl == 0)
        {
            character.GetComponent<MovementScript>().lvl = lastlvl;
        }
        if (lastlvl != character.GetComponent<MovementScript>().lvl)
        {
            lastlvl = character.GetComponent<MovementScript>().lvl;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length != 0)
            {
                destroyEnemies();
            }
        }
    }

    void destroyEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
            character.GetComponent<Spawn_Enemy>().Clear();
        }
    }
}
