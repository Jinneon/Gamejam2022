using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyType1 : Character
{
    public Transform tr;
    public float movePower = 1f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rig;
    //private Animator enemyAnimator;
    private int moveFlag = 0; //-1:Left,0:Idle, 1:Right
    private bool isTracing;
    private GameObject traceTarget;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //enemyAnimator = GetComponent<Animator>();
    }


    private void Start()
    {
        traceTarget = GetComponent<GameObject>();
        StartCoroutine(ChangeMove());
        tr = GetComponent<Transform>();
    }

    public void SetMonster()
    {
        CharacterHp = 100.0f;
        CharacterCp = 10.0f;
    }

    private void Update()
    {
        Move();

        Vector2 frontVec = new Vector2(rig.position.x + moveFlag * 0.2f, rig.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (rayHit.collider == null)
            Turn();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GetInstance().even?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GetInstance().even?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            traceTarget = other.gameObject;
            movePower = 3f;
            StopCoroutine("ChangeMove");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTracing = true;
            movePower = 3f;
            //enemyAnimator.SetBool("isMoving",true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTracing = false;
            movePower = 1f;
            StartCoroutine("ChangeMove");
        }
    }
    void Turn()
    {
        moveFlag *= -1;
        spriteRenderer.flipX = moveFlag == 1;

        CancelInvoke();
        Invoke("Move",0.5f);
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if(isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < tr.position.x)
                dist = "Left";
            else if (playerPos.x > tr.position.x)
                dist = "Right";
        }
        else
        {
            if (moveFlag == -1)
                dist = "Left";
            else if (moveFlag == 1)
                dist = "Right";
        }

        if(dist=="Left")
        {
            moveVelocity = Vector3.left;
        }

        else if(dist == "Right")
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    private IEnumerator ChangeMove()
        {
        moveFlag = Random.Range(-1, 1);

        if (moveFlag == 0)
        {
            //enemyAnimator.SetBool("isMoving", false);
        }
        else
        {
            //enemyAnimator.SetBool("isMoving", true);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine("ChangeMove");
    }
}
