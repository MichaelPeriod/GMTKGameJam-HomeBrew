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
        GSMScript = GameObject.Find("GameStateManager").GetComponent<ManageEvents>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            GSMScript.manageTriggerPress(TriggerID);
            active = true;
            gameObject.GetComponent<Animator>().SetBool("Active", true);
            Debug.Log("Active");
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            if(hold){
                GSMScript.manageTriggerRelease(TriggerID);
                active = false;
                gameObject.GetComponent<Animator>().SetBool("Active", false);
                Debug.Log("Deactivated");
            }
        }
    }
}
