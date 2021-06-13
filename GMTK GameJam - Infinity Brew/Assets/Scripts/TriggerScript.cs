using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public int TriggerID = 0;
    public bool hold = false;
    public bool active = false;
    private ManageEvents GSMScript;

    void Start(){
        GSMScript = GameObject.Find("GameManager").GetComponent<ManageEvents>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            //Trigger has been pressed
            GSMScript.manageTriggerPress(TriggerID); //Manage the press
            active = true; //Used for other objects checking the state, possably useless
            gameObject.GetComponent<Animator>().SetBool("Active", true); //Change animation state
            Debug.Log("Active");
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            if(hold){
                //Is toggleable and was released
                GSMScript.manageTriggerRelease(TriggerID); //Manage letting go
                active = false;//Used for other objects checking the state, possably useless
                gameObject.GetComponent<Animator>().SetBool("Active", false); //Change animation state
                Debug.Log("Deactivated");
            }
        }
    }
}
