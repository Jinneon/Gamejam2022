using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float Hp;
    private float Cp; //Combat Power
    private bool isDead;   

    public float CharacterHp { get => Hp; set => Hp = value; }
    public float CharacterCp { get => Cp; set => Cp = value; }
    public bool isCharacterDead { get => isDead; }

    protected virtual void OnEnable()
    {
        Hp = 100.0f;
        Cp = 10.0f;
        isDead = false;
    }

    public virtual void OnDamage(float damage)
    {
        Hp -= damage;

        if (Hp <= 0 && !isDead)
            Die();

    }

    public virtual void Die()
    {
        if(isDead)
        {
            //run dead animation
        }
    }
}
