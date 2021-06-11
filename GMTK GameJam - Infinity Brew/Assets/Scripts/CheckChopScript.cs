using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChopScript : MonoBehaviour
{
    public HingeJoint2D[] Chains;
    public bool chopping = false;
    // Start is called before the first frame update
    void Start()
    {
        Chains = GetComponentsInChildren<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void check(){
        PolygonCollider2D PC = gameObject.GetComponent<PolygonCollider2D>();
        PC.enabled = true;
        PC.isTrigger = true;

        Vector2 FarthestLeft = new Vector2(999, 999);
        Vector2 FarthestRight = new Vector2(-999, -999);
        Vector2 FarthestUp = new Vector2(-999, -999);
        Vector2 FarthestDown = new Vector2(999, 999);
        foreach (HingeJoint2D HJ in Chains){
            if(HJ.gameObject.GetComponent<Transform>().position.x + HJ.anchor.x < FarthestLeft.x){
                FarthestLeft = new Vector2(HJ.gameObject.GetComponent<Transform>().position.x, HJ.gameObject.GetComponent<Transform>().position.y);
            }

            if(HJ.gameObject.GetComponent<Transform>().position.x + HJ.anchor.x > FarthestRight.x){
                FarthestRight = new Vector2(HJ.gameObject.GetComponent<Transform>().position.x, HJ.gameObject.GetComponent<Transform>().position.y);
            }

            if(HJ.gameObject.GetComponent<Transform>().position.y + HJ.anchor.y < FarthestDown.y){
                FarthestDown = new Vector2(HJ.gameObject.GetComponent<Transform>().position.x, HJ.gameObject.GetComponent<Transform>().position.y);
            }

            if(HJ.gameObject.GetComponent<Transform>().position.y + HJ.anchor.y > FarthestUp.y){
                FarthestUp = new Vector2(HJ.gameObject.GetComponent<Transform>().position.x, HJ.gameObject.GetComponent<Transform>().position.y);
            }
        }

        List<Vector2> Farthest = new List<Vector2>();
        Farthest.Add(FarthestDown);
        Farthest.Add(FarthestRight);
        Farthest.Add(FarthestUp);
        Farthest.Add(FarthestLeft);

        PC.SetPath(0, Farthest);
    }

    void OnTriggerStay2D(Collider2D Trigger){
        //Not working????
        if(Trigger.CompareTag("Monster")){
            Debug.Log("Kill");
        }
    }
}