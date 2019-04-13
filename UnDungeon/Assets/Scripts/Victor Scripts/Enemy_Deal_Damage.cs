using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Deal_Damage : MonoBehaviour
{
    public int damage;
    public int timeBetweenDamageTick;
    Coroutine lastRoutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lastRoutine = StartCoroutine(Deal_Damage(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited trigger");
        if (lastRoutine != null)
        {
            StopCoroutine(lastRoutine);
        }
    }

    IEnumerator Deal_Damage(Collider2D collision)
    {
        while (enabled)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<HealthScript>().dealDamage(damage);
                yield return new WaitForSeconds(timeBetweenDamageTick);
                //Debug.Log("Waited for " + timeBetweenDamageTick + " seconds, and dealt " + damage + " damage.');
            }
        }
    }
}


