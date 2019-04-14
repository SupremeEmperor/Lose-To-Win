using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLevel : MonoBehaviour
{
    public GameObject character;

    void OnGUI()
    {
        GUIStyle UI = new GUIStyle();
        UI.font = Resources.Load<Font>("Fonts/Undungeon-normal");
        UI.fontSize = 26;
        UI.normal.textColor = Color.white;
        GUI.Label(new Rect(16, 10, 100, 100), "Level " + character.GetComponent<MovementScript>().lvl.ToString(), UI);
    }
}
