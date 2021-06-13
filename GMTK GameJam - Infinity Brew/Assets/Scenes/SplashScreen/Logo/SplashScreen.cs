using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    public Animator Panel;
    public GameObject FontText;
    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
	Invoke("ShowTxt", 3.6f);        
    }

    void ShowTxt()
    {
     	FontText.SetActive(true);
	Particle.SetActive(true);
	Invoke("FadeAway", 3f);   
    }
    void FadeAway() {
	Panel.SetTrigger("In");
	Invoke("SwitchScene", 1f);
    }
    void SwitchScene() {
	SceneManager.LoadScene("MainScreen");	
    }
}
