﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleJump : MonoBehaviour
{
    float dirX;

    [SerializeField]
    float jumpForce = 10f;
    
    public float moveSpeed = 5f;
    
    public float dec = 0.5f;
    public float topSpeed = 20.0f;
    public float airSpeed = 15F;
    public float acc = 0.0934375f;
    public float airAcc = 0.04671875f;
  
    public float gravity = 1;
    public float linearDrag = 4f;
    public float jumpDelay = 0.25f;
    public float delay = 0.25f;
    public float jumpCounter = 0;
  

   

    public float fallMultiplier = 5f;
    
    
    Rigidbody2D rb;

   public bool doubleJumpAllowed = false;
//   public bool onTheGround = false;
    bool facingRight = true;
    private BoxCollider2D box;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
      //  anim = GetComponent<Animator>();
    }
    public bool ground1;
    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            ground1 = true;
            jumpCounter = 0;
            
        }
        else
        {
            ground1 = false;
            doubleJumpAllowed = true;
        }
       
        MoPhysics();
        rb.velocity = new Vector2(dirX, rb.velocity.y);
        if (rb.velocity.y == 0)
        {
            
          //  onTheGround = true;
          //  anim.SetBool("isJumping", false);
        }
        else
        {
          //  onTheGround = false;
           // anim.SetBool("isJumping", true);
        }

      
        if (IsGrounded() && Input.GetButton("Jump"))
        {
           
           // anim.SetTrigger("takeOF");
            Jump();
        }
        else if( Input.GetButtonDown("Jump") && IsGrounded() == false)
        {
            
            if(jumpCounter <= 1)
            {
                Jump();
            }
            else
            {
                Debug.Log("Can jump only once");
            }
               
            doubleJumpAllowed = false;


            //    anim.SetBool("isJumping", true);
            //  doubleJumpAllowed = false;
        }
        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetKey(KeyCode.A) && IsGrounded())
        {
            if (moveSpeed < topSpeed)
            {
                moveSpeed += acc;



            }

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            moveSpeed -= dec;
            StartCoroutine(Decelaration());
        }

        if (Input.GetKey(KeyCode.A) && IsGrounded() == false)
        {
            if (moveSpeed < topSpeed)
            {
                moveSpeed += airAcc;
                if (moveSpeed >= airSpeed)
                    moveSpeed = airSpeed;
            }
        }



        IEnumerator Decelaration()
        {
            yield return new WaitForSeconds(delay);
            moveSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.D) && IsGrounded())
        {
            if (moveSpeed < topSpeed)
            {
                moveSpeed += acc;
                if (moveSpeed >= topSpeed)
                    moveSpeed = topSpeed;
            }

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            moveSpeed -= dec;
            StartCoroutine(Decelaration());

        }
        if (Input.GetKey(KeyCode.D) && IsGrounded() == false)
        {
            if (moveSpeed < topSpeed)
            {
                moveSpeed += airAcc;
                if (moveSpeed >= airSpeed)
                    moveSpeed = airSpeed;
            }
        }



        if (dirX < 0 && facingRight)
        {
            flip();
        }
        else if (dirX > 0 && !facingRight)
        {
            flip();
        }
        if (dirX == 0)
        {
          //  anim.SetBool("isWalking", false);
        }
        else
        {
          //  anim.SetBool("isWalking", true);
        }
        if (dirX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (dirX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    [SerializeField] private LayerMask ground;
    private bool IsGrounded()
    {
     
       // Debug.Log(jumpCounter);
   
       return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.2f, ground);
    }
     

    void Jump()
    {
        jumpCounter += 1;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity = Vector2.up * jumpForce;
        
        
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

 

    void OnCollisionEnter2D(Collision2D col)
    {
       
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Catfood"))
        {
            //Write code what happens when catfood is picked
            Destroy(other.gameObject);

        }
      /*  if (other.CompareTag(""))
        {
            



        }*/
      

    }

  

    
    void MoPhysics()
    {
        if ( IsGrounded())
        {
            if (Mathf.Abs(dirX) < 0.4f)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 1;
            }
            rb.gravityScale = 1;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }

    }
}
