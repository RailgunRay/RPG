using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 5f;
    private float currentPlayerSpeed;
    public float diagonalMoveModifier = 0.5f;

    private Animator anim;
    private bool playerMoving;
    public Vector2 lastMove;

    private Rigidbody2D playerRigidbody;
    private static bool playerExists;

    public bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;
 
    public AudioClip AttackAudio;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }     
	}
	
	// Update is called once per frame
	void Update ()
    {

        playerMoving = false;

        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentPlayerSpeed, playerRigidbody.velocity.y);
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            }



            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentPlayerSpeed);
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                playerRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
                AudioManager.instance.PlaySound(AttackAudio, transform.position);
            }

           

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentPlayerSpeed = playerSpeed * diagonalMoveModifier;
            }
            else
            {
                currentPlayerSpeed = playerSpeed;
            }
        }

        if (attackTimeCounter > 0f)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        else
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
