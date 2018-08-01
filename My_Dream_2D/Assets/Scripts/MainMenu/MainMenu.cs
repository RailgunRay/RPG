using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject Game;
    public GameObject _MainMenu;
    public GameObject _Menu;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startGame()
	{
        _MainMenu.SetActive(false);
        _Menu.SetActive(false);
        Game.SetActive(true);
        
    }
	public void exitGame()
	{
        Game.SetActive(false);
    }

}