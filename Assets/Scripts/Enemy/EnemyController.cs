using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public float speed;
	public int damageToPlayer;
	
	private Transform target;
	private bool isDead;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		SetInitialHealth();
	}
	
	// Update is called once per frame
	void Update () {
		MoveToTarget();
	}

	public void HurtEnemy(int damage){
		if(currentHealth - damage <= 0){
			Die();
		} else {
			currentHealth -= damage;
		}
	}

	public void Die(){
		isDead = true;
		Destroy(gameObject);
	}

	//sets inital health equal to max health
	public void SetInitialHealth(){
		currentHealth = maxHealth;
	}

	//sets initial health to a value passed, if over max health or under 0 it is set to maxHealth
	public void SetInitialHealth(int health){
		if(health > maxHealth | health <= 0){
			currentHealth = maxHealth;
		} else {
			currentHealth = health;
		}
	}

	private void MoveToTarget(){
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}

	//collision with objects
	public virtual void OnTriggerEnter2D(Collider2D collider){
		IPickable pickupScript = collider.gameObject.GetComponent<IPickable>();
		if(pickupScript != null){
			pickupScript.Take(this);
		}
	}

	//collision with player
	public virtual void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			GameController.Instance.playerHealth.HurtPlayer(damageToPlayer);
		}
	}
}
