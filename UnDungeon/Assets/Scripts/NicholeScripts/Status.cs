using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private static bool Won = false;

    public static bool WinGame
    {
        get
        {
            return Won;
        }
        set
        {
            Won = value;
        }
    }
}
