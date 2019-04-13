using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject[] beatOne;
    public GameObject[] beatTwo;
    public GameObject[] beatThree;
    public GameObject[] beatFour;
    public int bpm = 60;
    private int beatCount;
    private float beatInterval, beatTimer;


    // Start is called before the first frame update
    void Start()
    {
        beatCount = 0;
    }

    private void Update()
    {
        BeatFire();
    }

    public void BeatFire()
    {
        bool beatBool = false;
        beatInterval = bpm / 60;
        beatTimer += Time.deltaTime;
        if (beatTimer >= beatInterval)
        {
            beatBool = true;
            beatTimer -= beatInterval;
            beatCount++;
            if (beatCount >= 4)
            {
                beatCount -= 4;
            }
        }
        if (beatBool)
        {
            Fire(beatCount % 4);
        }
        

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
