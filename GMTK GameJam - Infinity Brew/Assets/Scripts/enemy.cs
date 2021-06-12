using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
	public enum EnemyTypes{
		Slime,
		Skelton,
		Spider
	};
	public EnemyTypes enemyType;
    public float maxSpeed;
	public float currSpeed = 0;
    public Animator anim;
    private Transform Target;
    public GameObject ProjectilePrefab;
    public Vector2 bulletStart;
    private Transform Player1;
    private Transform Player2;
    private int IncrementCounterOne = 0;
    private int IncrementCounterTwo = 0;
    private bool inShootingRange = false;
    private float bulletStartSpeed = 7.0f;
    public Vector2 direction;
    public float LineofSite = 5f;
	public float shootingDist = 4.5f;
    bool move = false;
    private HealthManager HM;
    private PlayerController P1;
    private PlayerController P2;
    void Start()
    {
     	Player1 = GameObject.Find("Player1").GetComponent<Transform>();   
	    Player2 = GameObject.Find("Player2").GetComponent<Transform>();
		P1 = GameObject.Find("Player1").GetComponent<PlayerController>();   
	    P2 = GameObject.Find("Player2").GetComponent<PlayerController>();
		HM = GameObject.Find("GameManager").GetComponent<HealthManager>();

		switch(enemyType){
			case EnemyTypes.Slime:
				maxSpeed = 1;
				break;
			case EnemyTypes.Skelton:
				maxSpeed = 0;
				bulletStartSpeed = 7f;
				break;
			case EnemyTypes.Spider:
				maxSpeed = 15;
				bulletStartSpeed = 4f;
				break;
		}
    }

    // Update is called once per frame
    void Update()
    {
	float P1difference = (Player1.position.x - transform.position.x) + (Player1.position.y - transform.position.y);
	float P2difference = (Player2.position.x - transform.position.x) + (Player2.position.y - transform.position.y);
	if (P2difference < P1difference) {
		Target = Player2;
	}
	else if (P1difference < P2difference) {
		Target = Player1;
	}
	Vector3 difference = Target.position - transform.position;
	float distanceFromPlayer = Vector2.Distance(Target.position, transform.position);
	if (distanceFromPlayer > LineofSite) {
		move = false;		
	}
	else {
		move = true;
	}
	if (transform.position.x < Target.position.x) {
		if (enemyType == EnemyTypes.Slime) {
			transform.localScale = new Vector3(1f, 1f, 1);
		}
		else if (enemyType == EnemyTypes.Skelton) {
			transform.localScale = new Vector3(6f, 6f, 1);
		}
	}
	else {
		if (enemyType == EnemyTypes.Slime) {
			transform.localScale = new Vector3(-1f, 1f, 1);
		}
		else if (enemyType == EnemyTypes.Skelton) {
			transform.localScale = new Vector3(-6f, 6f, 1);
		}
	}
	if (enemyType == EnemyTypes.Skelton) {
		if (distanceFromPlayer < shootingDist) 	
			inShootingRange = true;
		else
			inShootingRange = false;
	}
	transform.position = Vector2.MoveTowards(transform.position, Target.position,  currSpeed * Time.deltaTime);
	if (IncrementCounterOne == 0 && inShootingRange == false && move == true) {
		currSpeed = maxSpeed;
	}
	else {
		currSpeed = 0;
	}
		if (inShootingRange == true) {
			IncrementCounterTwo++;
			if (IncrementCounterTwo == 1) {
				float distance = difference.magnitude;
						direction = difference / distance;
						direction.Normalize();
					Shoot(direction);
			}
		}
    }
    void OnCollisionEnter2D (Collision2D other) {
    	if (other.gameObject.tag == "Bullet" && IncrementCounterOne == 0) {
		    IncrementCounterOne++;
		    if (IncrementCounterOne == 1) {
			    Invoke("des", 0.367f);
			    anim.SetTrigger("hurt");
		    }
	    }
	    if (other.gameObject.tag == "Player" && HealthManager.Cooldown == false) {
		    HM.looseHealth(10);
		    HM.StartCoroutine("WaitSystem");
		    P1.StartCoroutine("FlashCircle");
		    P2.StartCoroutine("FlashCircle");
	    }
    }
    void des() {
		IncrementCounterOne = 0;
    }
    void Shoot(Vector2 direction) {
	GameObject b = Instantiate(ProjectilePrefab) as GameObject;
        b.transform.position = bulletStart;
	b.GetComponent<Rigidbody2D>().velocity = direction * bulletStartSpeed;
	Invoke("Nadan", 2f);
	
    }
    void Nadan() {
		IncrementCounterTwo = 0;
    }

	void delete(){
		Destroy(gameObject);
	}
}
