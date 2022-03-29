using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int howManyHearts;
    public Image[] heartImages;
    public Sprite heart, noHeart;
    public List<int> uiCount;
   
    [SerializeField] private Color myColor;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth > howManyHearts)
        {
            playerHealth = howManyHearts;
        }

        for(int i = 0; i < heartImages.Length; i++)
        {
            if(i < playerHealth)
            {
                heartImages[i].sprite = heart;
            }
            else
            {


                heartImages[i].sprite = noHeart;
               
            }

            if(i < howManyHearts)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerHealth++;
            Debug.Log(playerHealth);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerHealth--;
            Debug.Log(playerHealth);
        }
        
    }
}
