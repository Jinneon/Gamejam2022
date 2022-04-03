using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
  [SerializeField]  private GameObject bulletPrefab;
 [SerializeField]   private Transform firePosition;
    private float fireRate = 0.25f;
    private float nextFire = 0f;

   // public KeyCode fireKey;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(0, 0, -90);
        if (Input.GetKey(KeyCode.L) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject _bullet = Instantiate(bulletPrefab, firePosition.position, target);
        }


    }
}