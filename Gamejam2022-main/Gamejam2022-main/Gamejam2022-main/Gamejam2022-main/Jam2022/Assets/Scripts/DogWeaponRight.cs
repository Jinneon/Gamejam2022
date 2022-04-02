using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWeaponRight : MonoBehaviour
{
    public GameObject TeleProjectile;
    public Transform firePosition;
    private float fireRate = 0.25f;
    private float nextFire = 0f;
 

    private float timeBtwShots;
    public float startTimeBtwShots;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        
        Quaternion target = Quaternion.Euler(0, 0, -90);
        if (timeBtwShots <= 0)
        {
            GameObject _bullet = Instantiate(TeleProjectile, firePosition.position, target);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}