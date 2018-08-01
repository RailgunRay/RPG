using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOpen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Dialogue NPC
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!GetComponent<InstantiateDialogue>().ShowDialogue)
            {
                var _VillagerMovement = gameObject.GetComponent<VillagerMovement>();
                _VillagerMovement.enabled = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                GetComponent<InstantiateDialogue>().ShowDialogue = true;
                var _VillagerMovement = gameObject.GetComponent<VillagerMovement>();
                _VillagerMovement.enabled = false;
            }
        }
    }
}
