using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject PauseUI;
	
	private bool paused = false;
	
	void start(){
		PauseUI.SetActive (true);
		
	}
	
	public void Restart(){
		Application.LoadLevel (1);
		
	}
	
	public void MainMenu(){
		Application.LoadLevel (0);
		
	}
	
	public void Quit(){
		Application.Quit ();
		
	}
}
