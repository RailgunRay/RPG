using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject[] inventory = new GameObject[10];
    public Button[] InventoryButtons = new Button[10];
    public GameObject mouseItem;
    private GameObject item = null;
    private GameObject forChange = null;
    private TriggerButton theTB;
    public bool HaveItem;
   
    




    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        //Find the first open slot in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + "was added");
                itemAdded = true;
                //Do something with Object
                item.SendMessage("DoInteractive");
                break;
            }
        }
        //inventory is full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item not Added");
        }
    }



    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //We found the item
                return true;
            }
        }
        return false;
    }


    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].GetComponent<InteractionObject>().itemType == itemType)
                {
                    //then we an item of the type we were looking for
                    return inventory[i];
                }

            }
        }
        //Item of type not found
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i] == item)
                {
                    //We found item - Remove it
                    inventory[i] = null;
                    Debug.Log(item.name + " was removed from inventory");
                    //Update UI
                    InventoryButtons[i].image.overrideSprite = null;
                    break;
                }
            }

        }
    }


    public void RemoveItemID(int ID)
    {
        if (Input.GetKey(KeyCode.Delete))
        {
            inventory[ID] = null;
            InventoryButtons[ID].image.overrideSprite = null;
        }
        //else
        //{
        //    mouseItem = null;
        //}
    }




    public void ChangeSlots(int ID, bool mouseHaveItem)
    {
        if (!mouseHaveItem)
        {
            mouseItem = inventory[ID];
            mouseItem.GetComponent<SpriteRenderer>().sprite = InventoryButtons[ID].image.overrideSprite;
            inventory[ID] = null;
            InventoryButtons[ID].image.overrideSprite = null;
            Debug.Log("Привет, я Компьютер я посетил функцию Change Slots");
            HaveItem = true;
        }
        else if(inventory[ID] == null)
        {
            forChange = mouseItem;
            inventory[ID] = forChange;
            //mouseItem = inventory[ID];
            Debug.Log("Привет, я Компьютер я посетил функцию Take Items");
            InventoryButtons[ID].image.overrideSprite = forChange.GetComponent<SpriteRenderer>().sprite;
            mouseItem.GetComponent<SpriteRenderer>().sprite = null;
            mouseItem = null;
            HaveItem = false;
        }
        else if(inventory[ID] != null)
        {
            forChange = mouseItem;
            mouseItem = inventory[ID];
            mouseItem.GetComponent<SpriteRenderer>().sprite = InventoryButtons[ID].image.overrideSprite;
            inventory[ID] = forChange;
            //mouseItem = inventory[ID];
            Debug.Log("Привет, я Компьютер я посетил функцию Take Items");
            //mouseItem.GetComponent<SpriteRenderer>().sprite = InventoryButtons[ID].image.overrideSprite;
            InventoryButtons[ID].image.overrideSprite = forChange.GetComponent<SpriteRenderer>().sprite;
            HaveItem = true;
        }
    }
}





    // public void TakeItem(int ID, bool mouseHaveItem)
    //{
    //    if (mouseItem != null && mouseHaveItem == true)
    //{
    //    forChange = mouseItem;
    //    mouseItem = inventory[ID];
    //    inventory[ID] = forChange;
    //    Debug.Log("Привет, я Компьютер я посетил функцию Take Items");
    //    InventoryButtons[ID].image.overrideSprite = forChange.GetComponent<SpriteRenderer>().sprite;
    //    if(mouseItem == null)
    //    {
    //        mouseHaveItem = false;
    //    }
    //        }
    //    }
    //}










