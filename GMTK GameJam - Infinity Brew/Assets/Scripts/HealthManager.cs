using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static int Health = 100;
    public static bool Cooldown = false;
    public float WaitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public IEnumerator WaitSystem() {
	Cooldown = true;
	yield return new WaitForSeconds(WaitTime);
	Cooldown = false;
     }
}
