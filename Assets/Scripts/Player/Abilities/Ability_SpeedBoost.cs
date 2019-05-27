using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_SpeedBoost : Ability {

		void Start () {
		abilityName = "Speed Boost";
		abilityDescription = "Increases the player movement speed";
		manaCost = 2;
	}

	public override void AbilityAction()
	{
		player.moveSpeed += 2;
	}
}
