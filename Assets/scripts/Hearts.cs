using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	public GameObject HUD;

	private Player player;
	
	void Start (){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			player.Plus(1);
			HUD.SetActive (false);
			
		}
		
	}
}
