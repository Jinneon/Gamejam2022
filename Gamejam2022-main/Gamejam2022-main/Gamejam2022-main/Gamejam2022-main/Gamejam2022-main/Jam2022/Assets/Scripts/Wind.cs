using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Windzone")
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 8000 * Time.deltaTime);
        if (col.tag == "Windzone1")
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8000 * Time.deltaTime);
        if (col.tag == "Windzone2")
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 18000 * Time.deltaTime);
        if (col.tag == "Windzone4")
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 18000 * Time.deltaTime);
        if (col.tag == "Windzone5")
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 18000 * Time.deltaTime);
    }
}
