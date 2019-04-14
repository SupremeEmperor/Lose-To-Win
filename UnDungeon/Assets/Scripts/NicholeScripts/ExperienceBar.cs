using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Image xpBar;
    public MovementScript moveScript;

    private void Start()
    {
        moveScript = GameObject.FindWithTag("Player").GetComponent<MovementScript>();
    }
    public void Update()
    {
        Debug.Log(moveScript.getXP());
        xpBar.fillAmount = moveScript.getXP() / 100f;
    }
}
