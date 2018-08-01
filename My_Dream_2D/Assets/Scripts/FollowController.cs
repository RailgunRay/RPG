using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPosition;
    public float markSpeed = 5;

    private static bool objectExists;


    void Start()
    {
      if (!objectExists)
        {
            objectExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
      else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, markSpeed * Time.deltaTime);
    }
}