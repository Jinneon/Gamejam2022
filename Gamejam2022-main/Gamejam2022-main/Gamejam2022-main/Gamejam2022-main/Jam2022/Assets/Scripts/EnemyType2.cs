using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyType2 : Character
{
    public Transform tr;
    public float movePower = 1f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rig;
    private Animator enemyAnimator;
    private int moveFlag = 0; //-1:Left,0:Idle, 1:Right
    private bool isTracing;
    private GameObject traceTarget;

    private float dist;
    private float tpRange = 4f;
    private float tpDelay = 5f;
    private float curTpTime;
    private bool bTeleport;
    private Vector2 tpPos;

    private void Awake()
    {
        
        rig = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       enemyAnimator = GetComponent<Animator>();
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
        if (traceTarget != null)
            dist = Vector2.Distance(tr.position, traceTarget.transform.position);
        Vector2 frontVec = new Vector2(rig.position.x + moveFlag * 0.2f, rig.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (rayHit.collider == null)
            Turn();

        if (dist <= tpRange && bTeleport && traceTarget != null)
            Teleportation();

        CheckTpCoolDown();
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
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;
            StopCoroutine("ChangeMove");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTracing = true;
            enemyAnimator.SetBool("isMoving",true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("ChangeMove");
            movePower = 1f;
        }
    }

    void Teleportation()
    {
        movePower = 3f;

        if (moveFlag == 1)
            tpPos.x = traceTarget.transform.position.x - 1.7f;
        if(moveFlag == -1)
            tpPos.x = traceTarget.transform.position.x + 1.7f;

        tpPos.y = traceTarget.transform.position.y;
        tr.position = tpPos;

        curTpTime = Time.time;
        bTeleport = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(tr.position, tpRange);
    }
    void CheckTpCoolDown()
    {
        if (curTpTime + tpDelay <= Time.time)
            bTeleport = true;
    }

    void Turn()
    {
        moveFlag *= -1;
        spriteRenderer.flipX = moveFlag == 1;

        CancelInvoke();
        Invoke("Move", 0.5f);
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
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

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            moveFlag = -1;
        }

        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            moveFlag = 1;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    private IEnumerator ChangeMove()
    {
        moveFlag = Random.Range(-1, 1);

        if (moveFlag == 0)
        {
            enemyAnimator.SetBool("isMoving", false);
        }
        else
        {
            enemyAnimator.SetBool("isMoving", true);
        }

        yield return new WaitForSeconds(5f);

        StartCoroutine("ChangeMove");
    }
}
