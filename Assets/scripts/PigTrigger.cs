using UnityEngine;
using System.Collections;

public class PigTrigger : MonoBehaviour {
	private Player player;
	private Animator animator;
	
	void Start (){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		animator = gameObject.GetComponent<Animator>();

	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			gameObject.GetComponent<Animation> ().Play ("pigcannon-wakeup");
			
		}
		
	}
}
