using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	public GameObject HUD;
	public GameObject Sfx;
	
	private Player player;
	
	void Start (){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Sfx.SetActive (false);
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			player.Coins(1);
			HUD.SetActive (false);
			Sfx.SetActive(true);

		}
		
	}
}
