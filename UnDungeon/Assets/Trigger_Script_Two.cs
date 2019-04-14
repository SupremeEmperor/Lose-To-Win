using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Script_Two : MonoBehaviour
{
    public Door_Script door;
    public GameObject movingCamera;
    public Moving_Camera_Scipt Mover;
    public Transform moveTo;
    public bool moving = false;
    public MovementScript character;
    public int levelToBe;
    public GameObject spawnToActivate;
    public GameObject spawnToDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.goThroughDoor();
            Mover.move(moveTo);
            character.lvl = levelToBe;
            character.exp = 0;
            spawnToDeactivate.SetActive(false);
            spawnToActivate.SetActive(true);
        }
    }
}
