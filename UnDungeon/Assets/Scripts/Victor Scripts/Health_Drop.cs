using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Drop : MonoBehaviour
{
    public int healthHealed;
    public int timeBeforeDissapear = 12;
        
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeBeforeDissapear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<HealthScript>().heal(healthHealed);
            Destroy(this.gameObject);
        }
    }
}
