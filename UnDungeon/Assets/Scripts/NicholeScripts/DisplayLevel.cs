using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
   // public GUIStyle UI_Style = new GUIStyle();
    public MovementScript moveScript;
    public Text levelDisplay;

    private void Start()
    {
        //UI_Style.font = Resources.Load<Font>("Fonts/Undungeon-normal");
        //UI_Style.fontSize = 36;
        //UI_Style.normal.textColor = Color.white;
        moveScript = GameObject.FindWithTag("Player").GetComponent<MovementScript>();
    }

    private void Update()
    {
        //Debug.Log("Is there");
        levelDisplay.text = "Level " + moveScript.lvl.ToString();
    }
    //void OnGUI()
    //{
    //    GUI.Label(new Rect(20, 20, 100, 100), "Level " + moveScript.lvl.ToString(), UI_Style);
    //}
}
