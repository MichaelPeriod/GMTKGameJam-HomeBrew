using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyball : MonoBehaviour
{
    private HealthManager HM;
    private PlayerController P1;
    private PlayerController P2;
    // Start is called before the first frame update
    void Start()
    {
		P1 = GameObject.Find("Player1").GetComponent<PlayerController>();   
	    P2 = GameObject.Find("Player2").GetComponent<PlayerController>();
	HM = GameObject.Find("GameManager").GetComponent<HealthManager>();
        Invoke("Des", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D other) {
    	if (other.gameObject.tag == "Player") {
		 HM.looseHealth(10);
		    HM.StartCoroutine("WaitSystem");
		    P1.StartCoroutine("FlashCircle");
		    P2.StartCoroutine("FlashCircle");
		Destroy(this.gameObject);
	}
    }
    void Des() {
	Destroy(this.gameObject);
    }
}
