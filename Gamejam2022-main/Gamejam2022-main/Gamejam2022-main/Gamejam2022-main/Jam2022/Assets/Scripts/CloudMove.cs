using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudMove : MonoBehaviour
{
   [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public CloudHeal playerhp;
    public Vector3 respawnPosition;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = respawnPosition;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
   
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "GameOver")
            {
                playerhp.OnDamage(0.5f);
                transform.position = respawnPosition;
            }
            else if (collision.tag == "CheckPoint")
            {
                respawnPosition = transform.position;
            }
            else if (collision.tag == "Bullet")
            {
                playerhp.OnDamage(0.5f);
            }
            else if (collision.tag == "Spike")
            {
                playerhp.OnDamage(0.5f);
            }
            else if (collision.tag == "Goal")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    
}
