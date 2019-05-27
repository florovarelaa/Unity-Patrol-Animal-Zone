using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BoxController : Respawn {

	//public PlayerAbilityManager playerAbilites;
	public int abilityInBox;

	// Use this for initialization
	void Start () {
		originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	//Random player ability is activated
	public override void Take (PlayerController player)
	{
		abilityInBox = player.GetComponent<PlayerAbilityManager>().RandomInactiveAbility();
		player.GetComponent<PlayerAbilityManager>().playerAbilities[abilityInBox].active = true;
	}

	//if enemy takes it nothing happens
    public override void Take(EnemyController enemy){
	
	}
}
