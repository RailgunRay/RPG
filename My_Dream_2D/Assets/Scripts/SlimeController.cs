using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    //private float timeToReload = 5f;
    //private bool reloading;
    //private GameObject thePlayer;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
            }

        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
            timeBetweenMoveCounter -= Time.deltaTime;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        //if (reloading)
        //{
        //    timeToReload -= Time.deltaTime;
        //    if (timeToReload <= 0f)
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //        //Application.LoadLevel(Application.loadedLevel);
        //        //thePlayer.gameObject.SetActive(true);
        //    }
        //}
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.name == "Player")
        //{
        //    other.gameObject.SetActive(false);
        //    thePlayer = other.gameObject;
        //    reloading = true;
        //}
    }
}
