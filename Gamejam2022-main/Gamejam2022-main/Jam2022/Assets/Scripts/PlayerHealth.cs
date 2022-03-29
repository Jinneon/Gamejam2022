using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float howManyHearts;
    public Image[] heartImages;
    public Sprite heart, noHeart, halfHeart;
    public List<int> uiCount;
   
    [SerializeField] private Color myColor;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > howManyHearts)
        {
            playerHealth = howManyHearts;
        }
        if (playerHealth == 0)
        {
            playerHealth = 0;
            Debug.Log("Game over");
        }

       

            // Debug.Log(i + " playerheart is " + playerHealth);
            if (playerHealth  == 3)
            {
                heartImages[0].sprite = heart;
                heartImages[1].sprite = heart;
                heartImages[2].sprite = heart;

            }
            else if(playerHealth == 2.5)
            {
                heartImages[0].sprite = halfHeart;
            heartImages[1].sprite = heart;
            heartImages[2].sprite = heart;
        }
            else if(playerHealth == 2)
            {
                heartImages[0].sprite = noHeart;
            heartImages[1].sprite = heart;
            heartImages[2].sprite = heart;
        }
            else if (playerHealth == 1.5)
            {
            heartImages[0].sprite = noHeart;
                heartImages[1].sprite = halfHeart;
            heartImages[2].sprite = heart;
            }
            else if (playerHealth == 1)
            {
            heartImages[0].sprite = noHeart;
                heartImages[1].sprite = noHeart;
            heartImages[2].sprite = heart;
            }
            else if (playerHealth == 0.5)
            {
            heartImages[0].sprite = noHeart;
            heartImages[1].sprite = noHeart;
            heartImages[2].sprite =  halfHeart;
            }
           else if(playerHealth == 0)
            {
                heartImages[2].sprite = noHeart;
            }




        
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerHealth += 0.5f ;
            Debug.Log(playerHealth);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerHealth--;
            Debug.Log(playerHealth);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth -= 0.5f;
        }
    }
        
}

