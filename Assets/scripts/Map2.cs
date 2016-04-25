﻿using UnityEngine;
using System.Collections;

public class Map2 : MonoBehaviour {
	private Player player;


	void Start (){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			Application.LoadLevel (4);
			
		}
		
	}

}
