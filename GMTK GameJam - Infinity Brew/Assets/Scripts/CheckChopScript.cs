using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChopScript : MonoBehaviour
{
    public Transform P1;
    public Transform P2;
    public List<Transform> Chains;
    public bool chopping = false;
    // Start is called before the first frame update
    void Start()
    {
        Chains.Add(P1);
        foreach(Transform child in gameObject.GetComponent<Transform>()){
            Chains.Add(child);
        }
        Chains.Add(P2);
        Chains.Add(P1); //Connect to start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void check(){
        PolygonCollider2D PC = gameObject.GetComponent<PolygonCollider2D>();
        PC.enabled = true;
        PC.isTrigger = true;
        List<Vector2> Points = new List<Vector2>();

        foreach (Transform Child in Chains)
        {
            Points.Add(new Vector2(Child.position.x, Child.position.y));
        }

        PC.SetPath(0, Points);
    }

    void OnTriggerStay2D(Collider2D Trigger){
        //Not working????
        //Debug.Log(Trigger.gameObject.tag);
        if(Trigger.gameObject.tag == "Monster"){
            Debug.Log("Die");
            Trigger.gameObject.GetComponent<Animator>().SetTrigger("Die");
        }
    }
}