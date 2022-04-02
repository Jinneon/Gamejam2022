using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] tutorialArray;
    public GameObject[] triggerArray;
    int count;
    int size;


    // Start is called before the first frame update
    void Start()
    {
        size = tutorialArray.Length;
        count = 0;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tutorial")
        {
            tutorialArray[count].SetActive(true);
            DestroyObject(tutorialArray[count], 2f);
            DestroyObject(triggerArray[count]);

            if (count < size)
                count++;
        }
    }
}
