using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject hurt;

	public float maxSpeed = 3;
	public float speed = 20;
	public float jumpPower = 500;

	public bool grounded;
	public bool canDoubleJump;

	public int currentHealth;
	public int maxHealth = 100;
	public int currentCoins;
	public int maxCoins = 100;

	private Rigidbody2D rigidBody2D;
	private Animator animator;

	void Start () {
		rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();

		currentHealth = maxHealth;
		currentCoins = maxCoins;

		hurt.SetActive (false);

	}
	
	void Update () {
		animator.SetBool("Grounded", grounded);
		animator.SetFloat("speed", Mathf.Abs(rigidBody2D.velocity.x));

		if(Input.GetAxis("Horizontal") < -0.1f){
			transform.localScale = new Vector3(-3, 2, 0f);

		}

		if(Input.GetAxis("Horizontal") > 0.1f){
			transform.localScale = new Vector3(3, 2, 0f);
			
		}

		if(Input.GetButtonDown("Vertical")){
			if(grounded){
				rigidBody2D.AddForce(Vector2.up * jumpPower);
				canDoubleJump = true;

			}else{
				if(!grounded){
					rigidBody2D.gravityScale = .2f;

				}

				if(canDoubleJump){
					canDoubleJump = false;
					rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0);
					rigidBody2D.AddForce(Vector3.up * jumpPower);

				}

			}
		}

		if (Input.GetButtonDown("Down")) {
			if(grounded){
				rigidBody2D.gravityScale = 1;

			}

			if(!grounded){
				rigidBody2D.gravityScale = 3;

			}
		
		}

		if(currentHealth > maxHealth){
			currentHealth = maxHealth;

		}

		if(currentHealth <= 0){
			Die ();

		}

		if(currentCoins > maxCoins){
			currentCoins = maxCoins;

		}

	}

	void FixedUpdate(){

		Vector3 easeVelocity = rigidBody2D.velocity;
		easeVelocity.y = rigidBody2D.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis("Horizontal");

		if(grounded){
			rigidBody2D.velocity = easeVelocity;

		}

		//player movement on x-Axis using a/d/left/right
		rigidBody2D.AddForce((Vector2.right * speed) * h);

		//limmiting speed of player 
		if(rigidBody2D.velocity.x > maxSpeed){
			rigidBody2D.velocity = new Vector2 (maxSpeed, rigidBody2D.velocity.y);
		}

		if(rigidBody2D.velocity.x < -maxSpeed){
			rigidBody2D.velocity = new Vector2 (-maxSpeed, rigidBody2D.velocity.y);
		}
	}

	void Die(){
		Application.LoadLevel (2);

	}

	public void Damage(int dmg){
		currentHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("demon-hurt");
		hurt.SetActive (true);
	}

	public void Plus(int plus){
		currentHealth += plus;
		
	}

	public void Coins(int coins){
		currentCoins += coins;

	}

	public IEnumerator KB(float KBDuration, float KBPwr, Vector3 KBDirection){
		float timer = 0;

		while(KBDuration > timer){
			timer += Time.deltaTime;

			rigidBody2D.AddForce(new Vector3(KBDirection.x * -1 , KBDirection.y * -1, transform.position.z));

		}
		yield return 0;

	}

}
