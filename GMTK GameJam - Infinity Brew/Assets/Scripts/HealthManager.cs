using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int Health = 100;
    public static bool Cooldown = false;
    public float WaitTime = 1f;
    public Slider Bar;
    // Start is called before the first frame update
    void Start()
    {
        Bar.value = Health / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void looseHealth(int looseAmt){
          Health -= looseAmt;
          Bar.value = Health / 100;
    }
     public IEnumerator WaitSystem() {
          Cooldown = true;
          yield return new WaitForSeconds(WaitTime);
          Cooldown = false;
     }
}
