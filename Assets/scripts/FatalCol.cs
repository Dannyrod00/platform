﻿using UnityEngine;
using System.Collections;

public class FatalCol : MonoBehaviour {

	private Player player;
	
	void Start (){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			player.Damage(6);
			
		}
		
	}

}
