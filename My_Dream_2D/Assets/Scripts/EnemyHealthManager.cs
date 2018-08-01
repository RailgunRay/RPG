using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public float MaxHealth;
    public float CurrentHealth;
    public int[] ChanceToDrop;
    public GameObject[] itemToDrop;
    
    public Image healthBar;
    public Image healthBackground;
    public Text enemyText;
    public string enemyName;

    private PlayerStats thePlayerStats;

    public int expToGive;

    // Use this for initialization
    void Start()
    {
        enemyText.text = enemyName;
        CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 0f);
        healthBackground.color = new Color(healthBackground.color.r, healthBackground.color.g, healthBackground.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurrentHealth <= 0)
        {
           
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);
            int dropORnot;
            for (int counter = 0; counter < ChanceToDrop.Length; counter++)
            {
                dropORnot = Random.Range(0, 100);
                if (dropORnot < ChanceToDrop[counter])
                {
                    Instantiate(itemToDrop[counter], transform.position, Quaternion.identity);
                }
            }
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
        ShowHealthBar(CurrentHealth, MaxHealth, healthBar);
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
    private void ShowHealthBar(float CurrentHealth, float MaxHealth, Image healthBar)
    {
        healthBackground.color = new Color(healthBackground.color.r, healthBackground.color.g, healthBackground.color.b, 0.6f);
        healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 1f);       
    }
}
