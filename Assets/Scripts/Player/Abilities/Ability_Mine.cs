using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Mine : Ability {

	public float timeToActivateMine;
	public int damage;

	//The object that will have the ability attached.
	public GameObject mine;

	public override void AbilityAction()
	{
		var go = Instantiate(this.mine, player.transform.position, Quaternion.Euler(Vector3.zero));
		go.AddComponent<Ability_Mine>();
	}
}
