using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour {

    public  int playerMaxHealth;
    public  int playerCurrentHealth;

    private bool flashActive;
    public float flashLenght = 0.5f;
    private float flashCounter;
    private SpriteRenderer playerSprite;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        playerCurrentHealth = playerMaxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (flashActive)
        {
            if (flashCounter > flashLenght * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }

            else if (flashCounter > flashLenght * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }

            else if(flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }

            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;

        }
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLenght;
        
    }

    public void HealPlayer(int healAmount)
    {
        if (playerCurrentHealth + healAmount > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
            
        }
        else
        {
            playerCurrentHealth += healAmount;
            
        }
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
        
    }
}
