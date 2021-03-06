using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    SpriteRenderer sr;
    public UnityEngine.Material matWhite;
    private UnityEngine.Material defaultMaterial;
    public PlayerHealth playerhp;
    private UnityEngine.Object flashParticle;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //matWhite = Resources.Load("Material/White", typeof(Material)) as UnityEngine.Material;
        defaultMaterial = sr.material;
        flashParticle = Resources.Load("FlashParticle");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            sr.material = matWhite;
            if(playerhp.CharacterHp <= 0)
            {
                Dead();
            }
            else
            {
                Invoke("ResetMaterial", .5f);
            }        
        }
    }

    void ResetMaterial()
    {
        sr.material = defaultMaterial;
    }

    private void Dead()
    {
        GameManager.GetInstance().even?.Invoke();
        GameObject flash = (GameObject)Instantiate(flashParticle);
        flash.transform.position = new Vector3(transform.position.x, transform.position.y + .3F, transform.position.z);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
           // Destroy(collision.gameObject);
            sr.material = matWhite;
            playerhp.OnDamage(0.5f);
            if (playerhp.CharacterHp <= 0)
            {
                Dead();
            }
            else
            {
                Invoke("ResetMaterial", .5f);
            }
        }
    }
}
