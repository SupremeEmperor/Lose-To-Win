using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Deal_Damage : MonoBehaviour
{
    public int damage;
    public int timeBetweenDamageTick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Deal_Damage(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(Deal_Damage(collision));
    }

    IEnumerator Deal_Damage(Collider2D collision)
    {
        while (enabled)
        {
            yield return new WaitForSeconds(timeBetweenDamageTick);
            collision.GetComponent<HealthScript>().dealDamage(damage);
            Debug.Log(collision);
            Debug.Log("Waited for " + timeBetweenDamageTick + " seconds, and it's now " + Time.time);
        }
    }
}


