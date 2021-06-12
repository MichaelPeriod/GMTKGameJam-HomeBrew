using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D RB;
    public float playerSpeed;
    public int playerNumber;
    public float cutDistance = 1f;
    public GameObject otherPlayer;
    public GameObject Chain;
    public SpriteRenderer Roomba;
    public Color transparent;
    public Color normal;
    public AudioSource source;
    public AudioClip chain;
    int add = 0;
    // Start is called before the first frame update
    void Start(){
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        Physics2D.IgnoreLayerCollision(1,4);
        //Move it based on if pressing, dev set speed, and time since last frame
        if (playerNumber == 1) {
            RB.AddForce(new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime * 100, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime * 100));
            if(Vector2.Distance(gameObject.GetComponent<Transform>().position, otherPlayer.GetComponent<Transform>().position) < cutDistance){
                if(!Chain.GetComponent<CheckChopScript>().chopping){
                    Chain.GetComponent<CheckChopScript>().check();
                }
            } else {
                Chain.GetComponent<CheckChopScript>().chopping = false;
                Chain.GetComponent<PolygonCollider2D>().enabled = false;
            }
        } else {
            RB.AddForce(new Vector2(Input.GetAxis("H2") * playerSpeed * Time.deltaTime * 100, Input.GetAxis("V2") * playerSpeed * Time.deltaTime * 100));
        }
	if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetAxis("H2") != 0 || Input.GetAxis("V2") != 0 ) {
		add++;
		if (add == 1) {
			source.clip = chain;
			source.Play();
		}
        }
	else {
		source.Stop();
		add = 0;
	}
    }
    public IEnumerator FlashCircle() {
	 Roomba.color = transparent; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = normal; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = transparent; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = normal; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = transparent; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = normal; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = transparent; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = normal; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = transparent; 
	 yield return new WaitForSeconds(0.1f);
	 Roomba.color = normal; 
	 yield return new WaitForSeconds(0.1f);
    } 
}
