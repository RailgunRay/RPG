using UnityEngine;

public class PlayerStats : MonoBehaviour
{   
    [Header("Arrays")]
    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    [Header("Variables")]
    public int currentLevel;
    public int currentExp;
    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start ()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentExp >= toLevelUp[currentLevel])
        {
            //currentLevel++;
            LevelUp();
        }	
	}

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += HPLevels[currentLevel] - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
}
