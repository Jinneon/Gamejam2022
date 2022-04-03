using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobermanHp : MonoBehaviour
{
    [SerializeField] private int hp;
    private Animator anim;
    bool onlyOnce = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "PlayerBullet")
        {
            hp -= 1;
            Debug.Log("Took damage");
           
        }
       
    }
    private void Update()
    {
        if(hp <= 0 && onlyOnce == false)
        {
            StartCoroutine(Die());
            onlyOnce = true;
        }
    }
    IEnumerator Die()
    {
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
