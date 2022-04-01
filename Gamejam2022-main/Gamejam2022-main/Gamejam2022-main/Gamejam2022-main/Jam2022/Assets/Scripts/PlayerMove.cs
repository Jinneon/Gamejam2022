using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAccelaration = 20f;

    //Direction where character is moving
    private Vector2 direction;
    //Velocity character should achieve
    private Vector2 desiredVelocity;
    //Current velocity
        private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;
    //How fast speed changes
    private float maxSpeedChange;
    private float accelaration;
    private bool onGround;
    bool facingRight = true;
    private Animator anim;
    public GameObject beachBall;
    public Transform beachPosition;
    public Vector3 respawnPosition;
    public PlayerHealth playerhp;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        anim = GetComponent<Animator>();
        transform.position = respawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Beachball");
            Instantiate(beachBall, beachPosition.transform.position, transform.rotation);

        }
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
        if (direction.x < 0 && facingRight)
        {
            flip();
        }
        else if (direction.x > 0 && !facingRight)
        {
            flip();
        }
        if (direction.x == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        accelaration = onGround ? maxAcceleration : maxAirAccelaration;
        maxSpeedChange = accelaration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GameOver")
        {
            playerhp.OnDamage(0.5f);
            transform.position = respawnPosition;
        }
        else if(collision.tag == "CheckPoint")
        {
            respawnPosition = transform.position;
        }
        else if (collision.tag == "Bullet")
        {
            playerhp.OnDamage(0.5f);
        }
    }


}
