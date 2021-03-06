using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public int Health = 100;
    public static bool Cooldown = false;
    public float WaitTime = 1f;
    public Slider Bar;
    public string Level;
    // Start is called before the first frame update
    void Start()
    {
        Bar.value = Health;
    }

    // Update is called once per frame
    void Update()
    {
	if (Health <= 0) {
		SceneManager.LoadScene(Level);
	}        
    }

    public void looseHealth(int looseAmt){
          Health -= looseAmt;
          Bar.value = Health;
    }
     public IEnumerator WaitSystem() {
          Cooldown = true;
          yield return new WaitForSeconds(WaitTime);
          Cooldown = false;
     }
}
