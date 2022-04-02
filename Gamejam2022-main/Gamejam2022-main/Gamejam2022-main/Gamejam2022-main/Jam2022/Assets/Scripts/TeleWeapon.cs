using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleWeapon : MonoBehaviour
{
    public float speed = 10;
    public int damage = 40;//
    Rigidbody2D rb;//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//
    }




    // Update is called once per frame
    void Update()
    {
        /*   Vector2 position = transform.position;

           position = new Vector2(position.x + speed * Time.deltaTime, position.y);

           transform.position = position;

           Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));*/
        Vector2 position = transform.position;


        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        transform.position = position;



        // { Destroy(gameObject); }
    }

 
   
}