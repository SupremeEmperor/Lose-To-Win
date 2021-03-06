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
    public GameObject character;
    bool shoot = false;


    // Start is called before the first frame update
    void Start()
    {
        beatCount = 1;
        shoot = false;
    }

    public void setShoot(bool input)
    {
        shoot = input;
    }

    private void FixedUpdate()
    {
        if(shoot)
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
        int lvl = character.GetComponent<MovementScript>().lvl;

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
                temp = beatFour.Length;
                break;
        }

        for (int i = 0; i < temp; i++)
        {
            
            switch (beat)
            {
                case 0:
                    //Debug.Log(1);
                    
                        if (beatOne[i].tag == "Shotgun" && lvl > 0)
                        {
                            beatOne[i].GetComponent<Shotgun>().Fire();
                        }

                        if (beatOne[i].tag == "Laser")
                        {
                            //beatOne[i].GetComponent<Laser>().Fire();
                        }

                        if (beatOne[i].tag == "TriShot" && lvl >= 2)
                        {
                            beatOne[i].GetComponent<TriShot>().Fire();
                        }
                        
                    break;
                case 1:
                    //Debug.Log(2);
                    if (beatTwo[i].tag == "Shotgun" && lvl > 0)
                    {
                        beatTwo[i].GetComponent<Shotgun>().Fire();
                    }

                    if (beatTwo[i].tag == "SpiralShot" && lvl >= 4)
                    {
                        beatTwo[i].GetComponent<Shotgun>().Fire();
                    }

                    break;
                case 2:
                    //Debug.Log(3);
                    if (beatThree[i].tag == "Shotgun" && lvl > 0)
                    {
                        beatThree[i].GetComponent<Shotgun>().Fire();
                    }

                    if (beatThree[i].tag == "BounceShot" && lvl >= 3)
                    {
                        beatThree[i].GetComponent<Shotgun>().Fire();
                    }
                    break;
                case 3:

                    if (beatFour[i].tag == "Shotgun" && lvl > 0)
                    {
                        beatFour[i].GetComponent<Shotgun>().Fire();
                    }

                    break;
            }
                
           
                
        }

    }
}
