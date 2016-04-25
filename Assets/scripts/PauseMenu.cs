using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	public GameObject Music;
	public GameObject Music1;

	private bool paused = false;

	void start(){
		PauseUI.SetActive (false);
	
	}

	void Update(){
		if(Input.GetButtonDown("Pause")){
			paused = !paused;
		
		}

		if(paused){
			PauseUI.SetActive(true);
			Time.timeScale = 0;
			Music1.SetActive(false);
			Music.SetActive(true);

		}

		if(!paused){
			PauseUI.SetActive(false);
			Time.timeScale = 1;
			Music1.SetActive(true);
			Music.SetActive(false);
		}
	}

	public void Resume(){
		paused = false;

	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
		
	}

	public void MainMenu(){
		Application.LoadLevel (0);
		
	}

	public void Quit(){
		Application.Quit ();
		
	}
	

}
