using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChopScript : MonoBehaviour
{
    public HingeJoint2D[] Chains;
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
        PolygonCollider PC = gameObject.AddComponent<PolygonCollider2D>();
        PC.isTrigger = true;
        foreach (var item in collection)
        {
            
        }
    }
}
