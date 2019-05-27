using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A basic attack common to every player.
public class Ability_BasicAttack : Ability {

	public int damage;

	void Start () {
		abilityName = "Basic Attack";
		abilityDescription = "A Basic attack that deals a small ammount of damage";
		manaCost = 0;
		active = true;
	}

	public override void Cast()
	{
		AbilityAction();
	}

	public override void AbilityAction()
	{
		
	}
}
