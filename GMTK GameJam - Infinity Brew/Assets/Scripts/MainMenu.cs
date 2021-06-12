using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject options; 
    public GameObject WRoomba;
    public GameObject BRoomba;
    public void Play()
    {
	Invoke("Level1", 0.2f);
    }
    public void Controls() {
	Invoke("Opti", 0.2f);
    }
    public void Exit()
    {
	Invoke("Quit", 0.2f);
    }
    public void Back() {
	Invoke("Left", 0.2f);
    }
    public void Backed() {
	Invoke("BackOptions", 0.2f);
    }
    void BackOptions() {
	options.SetActive(true);
	BRoomba.SetActive(false);
	WRoomba.SetActive(false);
     }
    public void RoombaWhite() {
	Invoke("WhiteRoomba", 0.2f);
    }
    public void RoombaBlack() {
	Invoke("BlackRoomba", 0.2f);
    }
    void BlackRoomba() {
	options.SetActive(false);
	BRoomba.SetActive(true);
	
    }
    void WhiteRoomba() {
	options.SetActive(false);
	WRoomba.SetActive(true);
	
    }
    void Level1() {
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }
    void Opti() {
	menu.SetActive(false);
	options.SetActive(true);
    }
    void Quit() {
	Application.Quit ();
    }
    void Left() {
	menu.SetActive(true);
	options.SetActive(false);
    }
}
