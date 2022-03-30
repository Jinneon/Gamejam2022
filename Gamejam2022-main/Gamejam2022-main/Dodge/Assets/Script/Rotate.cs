using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotaitionSpeed = 60f;
    private bool gm;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotaitionSpeed * Time.deltaTime, 0f);
    }
}
