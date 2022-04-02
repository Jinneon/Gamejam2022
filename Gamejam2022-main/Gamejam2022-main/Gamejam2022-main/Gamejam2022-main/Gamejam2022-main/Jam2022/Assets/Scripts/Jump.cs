using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField, Range(0f, 5)] private int maxJumps = 2;
    [SerializeField, Range(0f, 50f)] private float downwardMultiplier = 3f;
    [SerializeField, Range(0f, 10f)] private float upwardMultiplier = 1.7f;

    private Rigidbody2D rb;
    private Ground ground;
    private Vector2 velocity;

    private int jumpCounter;
    private float defaultGravityScale;
    private bool desiredJump;
    private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f;
    }
    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = rb.velocity;
        if (onGround)
        {
            jumpCounter = 0;
        }
        if (desiredJump)
        {
            desiredJump = false;
            JumpA();
        }
        //If going up
        if(rb.velocity.y > 0)
        {
            rb.gravityScale = upwardMultiplier;
        }
        //If down
        else if(rb.velocity.y < 0)
        {
            rb.gravityScale = downwardMultiplier;
            Debug.Log("Down");
        }
        else if (rb.velocity.y == 0)
        {
            rb.gravityScale = defaultGravityScale;
        }
        rb.velocity = velocity;

    }
    private void JumpA()
    {
        if(onGround || jumpCounter < maxJumps)
        {
            jumpCounter += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.RetrieveJumpInput();
    }
}
