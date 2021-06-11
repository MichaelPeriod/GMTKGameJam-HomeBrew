﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Animator anim;
    public Transform Target;
    public GameObject Projectile;
    public GameObject bulletStart;
    int Health = 3;
    public int enem;
    int add = 0;
    int man = 0;
    bool dude = false;
       public float bulletSpeed = 7.0f;
   public Vector2 direction;
    void Start()
    {
     	Target = GameObject.FindWithTag("Player").GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
	Vector3 difference = Target.position - transform.position;
	float distanceFromPlayer = Vector2.Distance(Target.position, transform.position);
	if (transform.position.x < Target.position.x) {
		transform.localScale = new Vector3(1f, 1f, 1);
	}
	else {
		transform.localScale = new Vector3(-1f, 1f, 1);
	}
	if (enem == 2) {
		if (distanceFromPlayer < 4.5) 	
			dude = true;
		else
			dude = false;
	}
	if (add == 0 && dude == false)
        	transform.position = Vector2.MoveTowards(transform.position, Target.position,  speed * Time.deltaTime);
	if (dude == true) {
		man++;
		if (man == 1) {
			float distance = difference.magnitude;
            		direction = difference / distance;
            		direction.Normalize();
	    		Shoot(direction);
		}
	}
	if (Health == 0) {
		Destroy(this.gameObject);
	}
    }
    void OnTriggerEnter2D (Collider2D other) {
    	if (other.gameObject.tag == "Bullet" && add == 0) {
		add++;
		if (add == 1) {
			Health -= 1;
			Invoke("des", 0.367f);
			anim.SetTrigger("hurt");
		}
	}
    }
    void des() {
	add = 0;
    }
    void Shoot(Vector2 direction) {
	GameObject b = Instantiate(Projectile) as GameObject;
        b.transform.position = bulletStart.transform.position;
	b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
	Invoke("Nadan", 2f);
	
    }
    void Nadan() {
	man = 0;
    }
}
