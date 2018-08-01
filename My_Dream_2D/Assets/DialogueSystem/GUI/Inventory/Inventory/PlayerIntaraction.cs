using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntaraction : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    private PlayerHealthManager thePHM;
    public bool stackablé;

    private void Start()
    {
        thePHM = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            //Check to see if this object is to be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }
            // check to see if this object can be opened;
            if(currentInterObjScript.openable)
            {
                //check to see  if the object is locked
                if (currentInterObjScript.locked)
                {
                    //check  to see if we have object  needed to unlock;
                    //Search our inventory for the item needed - if found unlock object
                    if(inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //We found the item needed
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + "was unlocked");
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + "was not unlocked");
                    }
                }
                else
                {
                    //object is not locked  - open the object
                    Debug.Log(currentInterObj.name + "is unlocked");
                    currentInterObjScript.Open();
                }

            }
        }
        //Use a potion
        if(Input.GetButtonDown("Use Potion"))
        { 
        GameObject potion = inventory.FindItemByType("Health Potion");
            if (potion != null)
            {
                inventory.RemoveItem(potion);
                thePHM.playerCurrentHealth += 10;
                if(thePHM.playerCurrentHealth > thePHM.playerMaxHealth)
                {
                    thePHM.playerCurrentHealth = thePHM.playerMaxHealth;
                }
                Debug.Log("Health Potion was used");

            }
            else
            {
                Debug.Log("Health Potion Not in the inventory");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
    }
}
