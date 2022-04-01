using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Character
{
    public SpriteRenderer spriterenderer;
    public float playerHealth;
    public float howManyHearts;
    public Image[] heartImages;
    public Sprite heart, noHeart, halfHeart;
    public List<int> uiCount;

    private bool invincibilityTime = false;
    private UnityEngine.Object flashParticle;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = CharacterHp = 3f;
        flashParticle = Resources.Load("FlashParticle");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = CharacterHp;
     //   Debug.Log("Player HP:" + playerHealth);

        if (playerHealth > howManyHearts)
        {
            playerHealth = howManyHearts;
        }
        if (playerHealth <= 0)
        {
            Die();
            playerHealth = 0;
            Debug.Log("Game over");
        }
       
        // Debug.Log(i + " playerheart is " + playerHealth);
        if (playerHealth == 3)
        {
            heartImages[0].sprite = heart;
            heartImages[1].sprite = heart;
            heartImages[2].sprite = heart;

        }
        else if (playerHealth == 2.5)
        {
            heartImages[0].sprite = heart;
            heartImages[1].sprite = heart;
            heartImages[2].sprite = halfHeart;
        }
        else if (playerHealth == 2)
        {
            heartImages[0].sprite = heart;
            heartImages[1].sprite = heart;
            heartImages[2].sprite = noHeart;
        }
        else if (playerHealth == 1.5)
        {
            heartImages[0].sprite = heart;
            heartImages[1].sprite = halfHeart;
            heartImages[2].sprite = noHeart;
        }
        else if (playerHealth == 1)
        {
            heartImages[0].sprite = heart;
            heartImages[1].sprite = noHeart;
            heartImages[2].sprite = noHeart;
        }
        else if (playerHealth == 0.5)
        {
            heartImages[0].sprite = halfHeart;
            heartImages[1].sprite = noHeart;
            heartImages[2].sprite = noHeart;
        }
        else if (playerHealth == 0)
        {
            heartImages[0].sprite = noHeart;
        }
    }

    public override void OnDamage(float damage)
    {
        if (!invincibilityTime)
        {
            CharacterHp -= damage;

            invincibilityTime = true;
            StartCoroutine("iTime");
        }
    }

    public override void Die()
    {
        isCharacterDead = true;
        GameManager.GetInstance().even?.Invoke();
        GameObject flash = (GameObject)Instantiate(flashParticle);
        flash.transform.position = new Vector3(transform.position.x, transform.position.y + .3F, transform.position.z);
        Destroy(gameObject);
    }

    IEnumerator iTime()
    {
        int countTime = 0;

        while(countTime <10)
        {
            if (countTime % 2 == 0)
                spriterenderer.color = new Color32(255, 255, 255, 90);
            else
                spriterenderer.color = new Color32(255, 255, 255, 180);

            countTime++;
            yield return new WaitForSeconds(0.2f);
        }
        spriterenderer.color = new Color32(255, 255, 255, 255);
        invincibilityTime = false;

        yield return null;
    }



}
