using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Pickup {

	public Ability_Mine mine;

	// Use this for initialization
	void Start () {
		Invoke("ActivateCollider", mine.timeToActivateMine);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ActivateCollider()
	{
		gameObject.GetComponent<Collider2D>().enabled = true;
	}

	//mine taken by player
	public override void Take (PlayerController player)
	{
		player.GetComponent<PlayerHealthManager>().HurtPlayer(mine.damage);
		Destroy(gameObject);
	}

	public override void Take(EnemyController enemy){
		enemy.GetComponent<EnemyController>().HurtEnemy(mine.damage);
		Destroy(gameObject);
	}
}
