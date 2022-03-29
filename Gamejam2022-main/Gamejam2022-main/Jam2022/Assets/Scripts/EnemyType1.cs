using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyType1 : Character
{
    public Transform tr;
    public LayerMask playerLayer;
    public float movePower = 1f;

    private Character targetPlayer;
    //private Animator enemyAnimator;
    private int moveFlag = 0; //0:Idle, 1:Left, 2:Right
    private bool isTracing;
    private GameObject traceTarget;

    private bool hasTarget
    {
        get
        {
            if (targetPlayer != null && !targetPlayer.isCharacterDead)
                return true;

            return false;
        }
    }

    private void Awake()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMove");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTracing = true;
            //enemyAnimator.SetBool("isMoving",true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("ChangeMove");
        }
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
            if (moveFlag == 1)
                dist = "Left";
            else if (moveFlag == 2)
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
        moveFlag = Random.Range(0, 3);

        if (moveFlag == 0)
        {
            //enemyAnimator.SetBool("isMoving", false);
        }
        else
        {
            //enemyAnimator.SetBool("isMoving", true);
        }

        yield return new WaitForSeconds(5f);

        StartCoroutine("ChangeMove");
    }

    public void Attack()
    {

    }

}
