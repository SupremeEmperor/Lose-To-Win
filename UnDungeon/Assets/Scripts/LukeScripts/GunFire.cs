using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject[] beatOne;
    public GameObject[] beatTwo;
    public GameObject[] beatThree;
    public GameObject[] beatFour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Fire(int beat)
    {
        for (int i = 0; i < beatOne.Length; i++)
        {
            Debug.Log(i);
            switch (beat)
            {
                case 1:
                    if(beatOne[i].tag == "Gun")
                    {
                        beatOne[i].GetComponent<Shotgun>().Fire();
                    }
                        
                    break;
            }
                
           
                
        }

    }
}
