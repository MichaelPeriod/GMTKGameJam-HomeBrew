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
    // Start is called before the first frame update
    void Start(){
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        //Move it based on if pressing, dev set speed, and time since last frame
        if (playerNumber == 1) {
            RB.AddForce(new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime * 100, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime * 100));
            if(Vector2.Distance(gameObject.GetComponent<Transform>().position, otherPlayer.GetComponent<Transform>().position) < cutDistance){
                Chain.GetComponent<CheckChopScript>().check();
            }
        } else {
            RB.AddForce(new Vector2(Input.GetAxis("H2") * playerSpeed * Time.deltaTime * 100, Input.GetAxis("V2") * playerSpeed * Time.deltaTime * 100));
        }
    }
}
