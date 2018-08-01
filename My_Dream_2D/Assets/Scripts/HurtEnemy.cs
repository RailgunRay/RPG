using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageDealtToEnemy;
    //public bool UseLaser = false;
    //public LineRenderer lineRenderer;

    private float[] floatArr = new float[10];

    private PlayerStats thePS;


	// Use this for initialization
	void Start ()
    {
        thePS = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAttack;
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageDealtToEnemy, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;

            for (int i = 0; i < floatArr.Length; i++)
            {
                floatArr[i] = Random.Range(0, 2.5f);
                Debug.Log(floatArr[i]);
            }

        }
    }

//    Void Laser()
//    {
//        lineRenderer.SetPositions(0, firepoint.position);
//        lineRenderer.SetPositions(1, target.position);
//    }
//        if(UseLaser)
//    {
//        Laser();
//    }
//else
//{
//    if(fireCountdown <= 0f)
//    {
//    Shoot();
//fireCountdown = 1f/ fireRate;
//    }
//    fireCountdown -= Time.deltaTime;
//    }
//    }

}

