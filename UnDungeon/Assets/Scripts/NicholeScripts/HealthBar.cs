using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public HealthScript healthScript;

    private void Start()
    {
        healthScript = GameObject.FindWithTag("Player").GetComponent<HealthScript>();
    }

    public void Update()
    {
        Debug.Log(healthScript.health);
        healthBar.fillAmount = healthScript.health / 100f;
    }
}
