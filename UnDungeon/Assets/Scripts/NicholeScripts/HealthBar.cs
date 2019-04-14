using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public GameObject character;

    public void Update()
    {
        healthBar.fillAmount = character.GetComponent<HealthScript>().health / 100f;
    }
}
