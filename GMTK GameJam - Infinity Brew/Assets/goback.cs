using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goback : MonoBehaviour
{
    // Start is called before the first frame update
    public void Back()
    {
     	SceneManager.LoadScene("MainScreen");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
