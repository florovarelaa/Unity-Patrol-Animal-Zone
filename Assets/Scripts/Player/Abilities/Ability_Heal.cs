using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An ability that heals the player by a value
public class Ability_Heal : Ability {

	public int healing = 10;

	public override void AbilityAction()
	{
		player.GetComponent<PlayerHealthManager>().HealPlayer(healing);
	}

}
