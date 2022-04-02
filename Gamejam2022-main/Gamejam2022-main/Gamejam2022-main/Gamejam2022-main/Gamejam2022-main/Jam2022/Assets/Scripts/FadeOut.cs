using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer r;
    public float fadeTime;
    public float startTime = 2f;
    public bool onlyOnce;
    public BoxCollider2D box;
    public GameObject platform;
    public float duration = 2f;
    public float appearAgainTime = 1f;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
         c = r.material.color;
        c.a = 100f;
        r.material.color = c;
        onlyOnce = false;
        fadeTime = startTime;
    }
    private void Update()
    {

        if (fadeTime <= 0 && onlyOnce == false)
        {
            StartCoroutine(FadeIn());
            fadeTime = startTime;
            onlyOnce = true;

            
        }
        else
        {
            fadeTime -= Time.deltaTime;
        }

        if (fadeTime == 0)
        {
            fadeTime = 0;
        }
       
    }

    IEnumerator FadeIn()
    {
      //  Debug.Log("Yo");
  
       
        
         
        c = r.material.color;
        c.a = 25f;
        r.material.color = c;
       
        yield return new WaitForSeconds(duration);
      //  Debug.Log("0");

        c = r.material.color;
        c.a = 0f;
        r.material.color = c;
        box.enabled = false;


        yield return new WaitForSeconds(appearAgainTime);
   //     Debug.Log("100");
        c = r.material.color;
        c.a = 100f;
        r.material.color = c;

        onlyOnce = false;
        box.enabled = true;
    }
}
