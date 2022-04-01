using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrap : MonoBehaviour
{
    public float speed;
   

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {



        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            Destroy(gameObject);

        }
    }
    

}
