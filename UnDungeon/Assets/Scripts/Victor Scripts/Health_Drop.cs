using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Drop : MonoBehaviour
{
    public int healthHealed;
        
    // Start is called before the first frame update
    void Start()
    {
        
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
