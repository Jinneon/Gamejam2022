using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
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
        Vector2 position = transform.position;

        position = new Vector2(position.x + -speed * Time.deltaTime, position.y);

        transform.position = position;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }
    void DestroyProjectile()
    {

        Destroy(gameObject);
    }
}