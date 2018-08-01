using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Collider2D walkZone;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private bool hasWalkZone;

	// Use this for initialization
	void Start ()
    {
        waitCounter = waitTime;
        walkCounter = walkTime;
        myRigidbody = GetComponent<Rigidbody2D>();
        ChooseDirection();
        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            

            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0f, moveSpeed);
                    if (hasWalkZone == true && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0f);
                    if (hasWalkZone == true && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0f, -moveSpeed);
                    if (hasWalkZone == true && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
                    if (hasWalkZone == true && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }
            if (walkCounter <= 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }

        else
        {
            myRigidbody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }

    private void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
