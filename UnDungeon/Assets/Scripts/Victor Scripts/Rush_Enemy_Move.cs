using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy_Move : MonoBehaviour
{
    private GameObject target;
    public string playerObjectName = "temp name";
    public int something = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find(playerObjectName);
    }
}
