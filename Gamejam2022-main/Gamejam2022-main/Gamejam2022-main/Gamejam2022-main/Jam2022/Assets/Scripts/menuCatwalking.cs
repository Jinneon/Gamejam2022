using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCatwalking : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        anim.SetBool("IsWalking", true);
    }
}
