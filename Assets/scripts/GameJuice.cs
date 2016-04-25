using UnityEngine;
using System.Collections;

public class GameJuice : MonoBehaviour {
	private Player player;

	public GameObject Juice;
	public GameObject sfx;
	
	void Start (){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		sfx.SetActive (false);
	}

	void timer () {
			player.maxSpeed = 150;
			player.jumpPower = 500;

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			Juice.SetActive (false);
			player.maxSpeed = 100;
			player.jumpPower = 200;
			Invoke ("timer",20);
			sfx.SetActive(true);
		}
		
	}

	
}
