using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLevitates : MonoBehaviour {

    private float levitateUp = 0.25f;
    private float levitateUpCounter;
    private float levitateDown = 0.25f;
    private float levitateDownCounter;

    private bool moveUP;
    public float levitateSpeed;

	// Use this for initialization
	void Start ()
    {
        moveUP = true;
        levitateUpCounter = levitateUp;
        levitateDownCounter = levitateDown;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveUP)
        {
            levitateUpCounter -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + levitateSpeed * Time.deltaTime, transform.position.z);
            if (levitateUpCounter < 0f)
            {
                moveUP = false;
                levitateDownCounter = levitateDown;
            }
        }
        else
        {
            levitateDownCounter -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y - levitateSpeed * Time.deltaTime, transform.position.z);
            if (levitateDownCounter < 0f)
            {
                moveUP = true;
                levitateUpCounter = levitateUp;
            }
        }

	}
}
