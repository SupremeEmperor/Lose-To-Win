using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public int levelToOpen1;
    private int levelToOpen2;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public MovementScript character;
    public bool passedDoor = false;
    public GameObject doorCheck1;
    public GameObject doorCheck2;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<MovementScript>();
        doorCheck1.SetActive(true);
        doorCheck2.SetActive(false);
        levelToOpen2 = levelToOpen1 + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (character.lvl == levelToOpen1 && !passedDoor)
        {
            Debug.Log("player did not pass the door and lvl is = to" + levelToOpen1);
            door1.SetActive(false);
            door2.SetActive(false);
            door3.SetActive(false);
            door4.SetActive(false);
        }
        else if (character.lvl == levelToOpen2 && passedDoor)
        {
            Debug.Log("player passed the door and lvl is = to" + levelToOpen2);
            door1.SetActive(false);
            door2.SetActive(false);
            door3.SetActive(false);
            door4.SetActive(false);
        }
        else
        {
            Debug.Log("Door is closed");
            door1.SetActive(true);
            door2.SetActive(true);
            door3.SetActive(true);
            door4.SetActive(true);
        }
        if (passedDoor)
        {
            doorCheck2.SetActive(true);
            doorCheck1.SetActive(false);
        }
        else if (!passedDoor)
        {
            doorCheck1.SetActive(true);
            doorCheck2.SetActive(false);
        }

    }

    public void goThroughDoor()
    {
        passedDoor = !passedDoor;
    }
}
