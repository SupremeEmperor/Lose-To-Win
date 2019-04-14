using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLevel : MonoBehaviour
{
    public MovementScript moveScript;

    private void Start()
    {
        moveScript = GameObject.FindWithTag("Player").GetComponent<MovementScript>();
    }

    void OnGUI()
    {
        GUIStyle UI = new GUIStyle();
        UI.font = Resources.Load<Font>("Fonts/Undungeon-normal");
        UI.fontSize = 26;
        UI.normal.textColor = Color.white;
        GUI.Label(new Rect(17, 12, 100, 100), "Level " + moveScript.lvl, UI);
    }
}
