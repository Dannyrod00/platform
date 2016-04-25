using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject PauseUI;
	
	private bool paused = false;
	
	void start(){
		PauseUI.SetActive (true);
		
	}

	public void Play(){
		Application.LoadLevel (1);
		
	}
	
	public void Controls(){
		Application.LoadLevel (3);
		
	}

	public void Quit(){
		Application.Quit ();
		
	}

}
