using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCrown : MonoBehaviour
{
    public GameObject Crown;

    private void Start()
    {
        if (!Status.WinGame)
        {
            Crown.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            Crown.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
}
