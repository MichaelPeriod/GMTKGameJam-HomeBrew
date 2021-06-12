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
    // Start is called before the first frame update
    void Start(){
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
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
