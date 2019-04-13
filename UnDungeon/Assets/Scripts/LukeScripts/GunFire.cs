﻿using System.Collections;
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
        beatCount = 1;
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
        }
        if(beatCount == 4)
        {
            beatCount = 0;
        }

        
        if (beatBool)
        {
            int temp = (beatCount % 4);
            Fire(temp);
        }
        

    }

    // Update is called once per frame
    public void Fire(int beat)
    {
        int temp = 0;
        switch (beat)
        {
            case 0:
                temp = beatOne.Length;
                break;
            case 1:
                temp = beatTwo.Length;
                break;
            case 2:
                temp = beatThree.Length;
                break;
            case 3:
                temp = beatThree.Length;
                break;
        }

        for (int i = 0; i < temp; i++)
        {
            
            switch (beat)
            {
                case 0:
                    
                    
                        if (beatOne[i].tag == "Shotgun")
                        {
                            beatOne[i].GetComponent<Shotgun>().Fire();
                        }

                        if (beatOne[i].tag == "Laser")
                        {
                            //beatOne[i].GetComponent<Laser>().Fire();
                        }

                        if (beatOne[i].tag == "TriShot")
                        {
                            beatOne[i].GetComponent<TriShot>().Fire();
                        }
                        
                    break;
                case 1:
                    if (beatTwo[i].tag == "Shotgun")
                    {
                        beatTwo[i].GetComponent<Shotgun>().Fire();
                    }

                    break;
                case 2:
                    if (beatThree[i].tag == "Shotgun")
                    {
                        beatThree[i].GetComponent<Shotgun>().Fire();
                    }

                    break;
                case 3:
                    if (beatFour[i].tag == "Shotgun")
                    {
                        beatFour[i].GetComponent<Shotgun>().Fire();
                    }

                    break;
            }
                
           
                
        }

    }
}
