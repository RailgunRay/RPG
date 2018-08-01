using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {


    public bool inventory; //if true this object can be store in inventory;
    public string itemType; // this will tell what type of item this object is;
    public bool openable;  // if this is true this object can be open;
    public bool locked; // if this is true object is locked;
    public GameObject itemNeeded; // item needed in order to interact with this item;
    public bool stackable;
    public Animator anim;
		
	public void DoInteractive()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

}
