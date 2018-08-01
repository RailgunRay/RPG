using UnityEngine;

public class healPlayer : MonoBehaviour {

    private PlayerHealthManager thePlayer;
    public int healAmount;

	// Use this for initialization
	void Start ()
    {
        thePlayer = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            thePlayer.HealPlayer(healAmount);
        }
    }
}
