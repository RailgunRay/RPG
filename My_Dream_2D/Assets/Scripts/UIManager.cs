using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healtBar;
    public Text HPText;
    public Text levelText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePS;

    private static bool UIExists;

	// Use this for initialization
	void Start ()
    {
        if (!UIExists)
        {
            UIExists = true;
           
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        healtBar.maxValue = playerHealth.playerMaxHealth;
        healtBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP : " + playerHealth.playerCurrentHealth.ToString() + "/" + playerHealth.playerMaxHealth.ToString();
        levelText.text = "Lvl : " + thePS.currentLevel; 
    }
}
