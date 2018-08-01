using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour {

    private Inventory theInv;
    public int myID;
    private GameObject item;
    private bool MouseHaveItem;

    private void Start()
    {
         theInv = FindObjectOfType<Inventory>();
    }

    public void DeleteItem()
    {
        theInv.RemoveItemID(myID);
    }

    public void ChangeSlots()
    {
      theInv.ChangeSlots(myID, theInv.HaveItem);
    }

    //public void TakeItems()
    //{
    //    theInv.TakeItem(myID, theInv.HaveItem);
    //}
}
