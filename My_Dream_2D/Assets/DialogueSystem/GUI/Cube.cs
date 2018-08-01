using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private InstantiateDialogue theID;

    // Use this for initialization
    void Start()
    {
        theID = FindObjectOfType<InstantiateDialogue>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (PlayerPrefs.GetInt("Quest1") == 1)
            {
                PlayerPrefs.SetInt("Quest1", 2);
            }
        }
    }
}


